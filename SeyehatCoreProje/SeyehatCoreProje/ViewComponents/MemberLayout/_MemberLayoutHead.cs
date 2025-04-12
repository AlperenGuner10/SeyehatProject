using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.MemberLayout
{
	public class _MemberLayoutHead : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
