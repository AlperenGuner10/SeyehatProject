using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Controllers
{
	[AllowAnonymous]
	public class GuideController : Controller
	{
		GuideManager guideManager = new GuideManager(new EfGuideDal());
		public IActionResult Index()
		{
			var values = guideManager.GetAll();
			return View(values);
		}
	}
}
