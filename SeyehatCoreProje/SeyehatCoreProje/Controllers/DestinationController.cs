using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
	{
		DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
		private readonly UserManager<AppUser> _userManager;

		public DestinationController(UserManager<AppUser> userManager)
		{
			_userManager=userManager;
		}
		public IActionResult Index()
		{
			var values = _destinationManager.GetAll();
			return View(values);
		}
		public async Task<IActionResult> DestinationDetails(int id)
		{
			ViewBag.i = id;
			ViewBag.destID = id;
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.userID = value.Id;
			var values = _destinationManager.TGetDestinationWithGuide(id);
			return View(values);
		}
	}
}
