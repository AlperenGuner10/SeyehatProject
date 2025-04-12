using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SeyehatCoreProje.Models;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(MailRequest mailRequest)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin","admin1@gmail.com");//gmail hesabı oluşturulmadı
			mimeMessage.From.Add(mailboxAddressFrom);//kimden geldi

			MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequest.RecieverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = mailRequest.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = mailRequest.Subject;

			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com",587,false);
			smtpClient.Authenticate("admin1@gmail.com", "123456Aa*");//gmail şifresi örnek olarak ancak hesap oluşturulmadı. iki aşamalı doğrulamayı açıp uygulama şifresi oluştur. 123.. yazan yere ekle.
			smtpClient.Send(mimeMessage);
			smtpClient.Disconnect(true);
			return View();
		}
	}
}
