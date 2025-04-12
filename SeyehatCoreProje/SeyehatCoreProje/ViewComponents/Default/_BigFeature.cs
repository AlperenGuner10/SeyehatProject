using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Default
{
	public class _BigFeature : ViewComponent
	{
		BigFeatureManager bigFeatureManager = new BigFeatureManager(new EfBigFeatureDal());

		public IViewComponentResult Invoke()
		{
			//var values = bigFeatureManager.GetAll();
			//ViewBag.image1 = bigFeatureManager.ge
			return View();
		}
	}
}
