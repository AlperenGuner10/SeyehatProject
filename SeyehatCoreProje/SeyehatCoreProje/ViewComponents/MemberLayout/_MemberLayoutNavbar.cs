using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.MemberLayout
{
	public class _MemberLayoutNavbar : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
