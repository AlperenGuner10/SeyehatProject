using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class ContactUSController : Controller
	{
		private readonly IContactUsService _contactUsService;

		public ContactUSController(IContactUsService contactUsService)
		{
			_contactUsService=contactUsService;
		}

		public IActionResult Index()
		{
			var values = _contactUsService.TGetListContactUsByTrue();
			return View(values);
		}
	}
}
