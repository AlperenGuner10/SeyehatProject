using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.Areas.Admin.Models;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService=accountService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(AccountViewModel account)
		{
			var valuesSender = _accountService.TGetByID(account.SenderId);
			var valuesReceiver = _accountService.TGetByID(account.RecieveId);

			valuesSender.Balance -= account.Amount;
			valuesReceiver.Balance += account.Amount;

			List<Account> accounts = new List<Account>()
			{
				valuesSender,
				valuesReceiver
			};

			_accountService.TMultiUpdate(accounts);
			return View();
		}
	}
}
