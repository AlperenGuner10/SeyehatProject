using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.Areas.Member.Models;

namespace SeyehatCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new();
			userEditViewModel.name = values.Name;
			userEditViewModel.surname = values.Surname;
			userEditViewModel.phonenumber = values.PhoneNumber;
			userEditViewModel.mail = values.Email;
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel m) //kullanıcı profil içerisine resim kayıt etmek için yapıldı
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if(m.image != null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(m.image.FileName);
				var imagename = Guid.NewGuid() + extension;
				var savelocation = resource + "/wwwroot/userImage/"+ imagename;
				var stream = new FileStream(savelocation, FileMode.Create);
				await m.image.CopyToAsync(stream);
				user.ImageUrl = imagename;
			}
			user.Name = m.name;
			user.Surname = m.surname;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,m.password);
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}
