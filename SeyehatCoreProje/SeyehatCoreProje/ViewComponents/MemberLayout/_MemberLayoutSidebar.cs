using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.MemberLayout
{
	public class _MemberLayoutSidebar : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
