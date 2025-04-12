using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Default
{
	public class _PopularDestinations : ViewComponent
	{
		DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
		public IViewComponentResult Invoke()
		{
			var values = _destinationManager.GetAll();
			return View(values);
		}
	}
}
