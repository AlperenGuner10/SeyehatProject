using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Default
{
	public class _Statistics : ViewComponent
	{
		Context cnt = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = cnt.Destinations.Count();
			ViewBag.v2 = cnt.Guides.Count();
			ViewBag.v3 = "285";
			return View();
		}
	}
}
