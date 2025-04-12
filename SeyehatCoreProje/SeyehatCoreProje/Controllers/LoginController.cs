using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.Models;

namespace SeyehatCoreProje.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;//giriş yapmak için kullanılır
		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(UserRegisterViewModel u)  //identity
		{
			AppUser appUser = new()
			{
				Name = u.Name,
				Surname = u.Surname,
				Email = u.Mail,
				UserName = u.Username,
			};
			if (u.Password == u.ConfirmPassword)
			{
				var result = await _userManager.CreateAsync(appUser, u.Password);
				if (result.Succeeded)
				{
					return RedirectToAction("SignIn");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(u);
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(UserSignInViewModel v)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(v.Username, v.Password, false, true);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Profile", new { area = "Member" });
				}
				else
				{
					return RedirectToAction("SignIn", "Login");
				}
			}
			return View();
		}
	}
}
