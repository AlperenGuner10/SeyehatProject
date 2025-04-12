using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Serilog;
using SeyehatCoreProje.CQRS.Handlers.DestinationHandlers;
using SeyehatCoreProje.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();

builder.Services.AddMediatR(typeof(Program));


var path = Directory.GetCurrentDirectory();
var logDirectory = Path.Combine(path, "Loglar");

Directory.CreateDirectory(logDirectory);

Log.Logger = new LoggerConfiguration()
	.WriteTo.File(Path.Combine(logDirectory, "Log1.txt"))
	.CreateLogger();

// Logging servisini Serilog ile entegre et
var loggerFactory = LoggerFactory.Create(builder =>
{
	builder.AddSerilog();
	builder.ClearProviders();
	builder.SetMinimumLevel(LogLevel.Debug);
	builder.AddDebug();
});

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().
	AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();

builder.Services.AddHttpClient();

builder.Services.ContainerDependencies();//auto mapper iþlemi

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.CustomValidator();
builder.Services.AddControllersWithViews().AddFluentValidation();//validasyon iþlemi

builder.Services.Configure<IdentityOptions>(options => //Þifre için istenilen deðerleri burada deðiþtirebiliriz.
{
	options.Password.RequiredLength = 6;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireDigit = true;
});


builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder().
				RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});

//dil desteði
builder.Services.AddLocalization(opt =>
{
	opt.ResourcesPath="Resources";
});
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();



builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath="/Login/SignIn";
});


var app = builder.Build();

// Logger nesnesi ile log kaydý ekleme
var logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("Uygulama baþlatýldý ve log dosyasý oluþturuldu.");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.MapControllers();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//dil desteði
var suppertedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertedCultures[4]).AddSupportedCultures(suppertedCultures).AddSupportedUICultures(suppertedCultures);
app.UseRequestLocalization(localizationOptions);

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");



app.Run();
