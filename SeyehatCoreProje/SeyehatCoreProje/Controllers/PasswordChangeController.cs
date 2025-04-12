using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SeyehatCoreProje.Models;

namespace SeyehatCoreProje.Controllers
{
	[AllowAnonymous]
	public class PasswordChangeController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public PasswordChangeController(UserManager<AppUser> userManager)
		{
			_userManager=userManager;
		}
		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
		{
			var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail.ToLower());

			if (user == null)
			{
				ModelState.AddModelError("", "Bu e-posta adresine sahip bir kullanıcı bulunamadı.");
				return View();
			}

			if (!await _userManager.IsEmailConfirmedAsync(user))
			{
				ModelState.AddModelError("", "E-posta adresiniz doğrulanmamış. Lütfen önce e-posta doğrulama işlemini tamamlayın.");
				return View();
			}

			string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

			var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
			{
				userId = user.Id,
				token = passwordResetToken
			}, HttpContext.Request.Scheme);

			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "admin1@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = $"Şifrenizi sıfırlamak için <a href='{passwordResetTokenLink}'>buraya tıklayın</a>";
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = "Şifre Değişiklik Talebi";

			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);

			// Gmail şifresi yerine, uygulama şifresi kullanman gerekiyor.
			smtpClient.Authenticate("admin1@gmail.com", "GMAIL_UYGULAMA_SIFRESI");
			smtpClient.Send(mimeMessage);
			smtpClient.Disconnect(true);

			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string userid, string token)
		{
			TempData["userid"] = userid;
			TempData["token"] = token;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
		{
			var userid = TempData["userid"];
			var token = TempData["token"];
			if (userid == null || token == null)
			{
				//hata
			}
			var user = await _userManager.FindByIdAsync(userid.ToString());
			var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}
