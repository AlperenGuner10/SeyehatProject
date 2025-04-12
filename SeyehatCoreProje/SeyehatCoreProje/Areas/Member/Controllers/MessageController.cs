using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Areas.Member.Controllers
{
	public class MessageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
