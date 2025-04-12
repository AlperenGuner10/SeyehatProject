using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	[AllowAnonymous]
	public class DestinationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
		public IActionResult Index()
		{
			var values = destinationManager.GetAll();
			return View(values);
		}
		public IActionResult GetCitiesSearchByName(string searchString)
		{
			ViewData["CurrentFilter"] = searchString;
			var values = from x in destinationManager.GetAll() select x;
			if(!string.IsNullOrEmpty(searchString) )
			{
				values = values.Where(x=>x.City.Contains(searchString));
			}
			return View(values.ToList());
		}
	}
}
