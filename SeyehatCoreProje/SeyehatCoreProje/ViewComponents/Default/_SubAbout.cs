using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Default
{
	public class _SubAbout : ViewComponent
	{
		SubAboutManager _subAboutManager = new SubAboutManager(new EfSubAboutDal());
		public IViewComponentResult Invoke()
		{
			var values = _subAboutManager.GetAll();
			return View(values);
		}
	}
}
