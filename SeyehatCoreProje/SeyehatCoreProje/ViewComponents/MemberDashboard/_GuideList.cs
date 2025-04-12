using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.MemberDashboard
{
	public class _GuideList : ViewComponent
	{
		GuideManager guideManager = new GuideManager(new EfGuideDal());
		public IViewComponentResult Invoke()
		{
			var values = guideManager.GetAll();
			return View(values);
		}
	}
}
