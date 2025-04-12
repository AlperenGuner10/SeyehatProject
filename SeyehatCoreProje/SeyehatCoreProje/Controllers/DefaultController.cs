using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace SeyehatCoreProje.Controllers
{

	public class DefaultController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
	}
}
