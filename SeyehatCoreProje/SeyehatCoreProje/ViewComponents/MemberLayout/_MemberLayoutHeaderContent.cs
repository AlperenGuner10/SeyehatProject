using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.MemberLayout
{
	public class _MemberLayoutHeaderContent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
