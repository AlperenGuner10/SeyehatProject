using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.Models;

namespace SeyehatCoreProje.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			_logger.LogInformation("Index Sayfasý Çaðrýldý");
			_logger.LogError("Error Log Çaðrýldý");
			return View();
		}

		public IActionResult Privacy()
		{
			_logger.LogInformation("Privacy Sayfasý Çaðrýldý");
			return View();
		}
		public IActionResult Test()
		{
			DateTime d = Convert.ToDateTime(DateTime.Now.ToLongTimeString());
			_logger.LogInformation(d + "Test Sayfasý Çaðýrýldý");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
