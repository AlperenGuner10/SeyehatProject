using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.AdminDashboard
{
	public class _AdminDashboardHeader : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
