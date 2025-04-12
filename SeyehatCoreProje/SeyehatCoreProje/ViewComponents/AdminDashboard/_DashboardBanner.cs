using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.AdminDashboard
{
	public class _DashboardBanner : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
