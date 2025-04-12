using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SeyehatCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	public class ReservationController : Controller
	{
		DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
		ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

		private readonly UserManager<AppUser> _userManager;
		public ReservationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;	
		}
		public async Task<IActionResult> MyCurrentReservation()//Geçerli Rezervasyonlar
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = reservationManager.GetListWithReservationByAccepted(values.Id);
			return View(valuesList);
		}
		public async Task<IActionResult> MyOldReservation()//Eski Rezervasyonlar
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = reservationManager.GetListWithReservationByPast(values.Id);
			return View(valuesList);
		}
		public async Task<IActionResult> MyApprovalReservation()//Onay bekleyen rezervasyonlar
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = reservationManager.GetListWithReservationByWaitApproval(values.Id);
			return View(valuesList);
		}
		[HttpGet]
		public IActionResult NewReservation()
		{
			List<SelectListItem> list = (from x in destinationManager.GetAll()
										 select new SelectListItem
										 {
											 Text=x.City,
											 Value=x.DestinationId.ToString()
										 }).ToList();
			ViewBag.x = list;
			return View();
		}
		[HttpPost]
		public IActionResult NewReservation(Reservation r)
		{
			r.AppUserId =5;
			r.Status = "Onay Bekliyor";
			reservationManager.TAdd(r);
			return RedirectToAction("MyCurrentReservation");
		}
	}
}
