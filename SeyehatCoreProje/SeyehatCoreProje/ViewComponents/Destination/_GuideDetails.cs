using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Destination
{
	public class _GuideDetails : ViewComponent
	{
		private readonly IGuideService _guideService;

		public _GuideDetails(IGuideService guideService)
		{
			_guideService=guideService;
		}
		public IViewComponentResult Invoke()
		{
			var values = _guideService.TGetById(12);
			return View(values);
		}
	}
}
