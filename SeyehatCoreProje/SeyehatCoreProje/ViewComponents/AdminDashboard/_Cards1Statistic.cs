using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.AdminDashboard
{
	public class _Cards1Statistic : ViewComponent
	{
		Context cnt = new Context();
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = cnt.Destinations.Count();
			ViewBag.v2 = cnt.Users.Count();
			return View();
		}
	}
}
