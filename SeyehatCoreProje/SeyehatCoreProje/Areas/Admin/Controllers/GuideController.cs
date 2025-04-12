using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class GuideController : Controller
	{
		private readonly IGuideService _guideService;

		public GuideController(IGuideService guideService)
		{
			_guideService=guideService;
		}

		public IActionResult Index()
		{
			var values = _guideService.GetAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddGuide()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddGuide(Guide guide)
		{
			GuideValidator validations = new GuideValidator();
			ValidationResult validationResult = validations.Validate(guide);
			if (validationResult.IsValid)
			{
				_guideService.TAdd(guide);
				return RedirectToAction("Index","Guide", new {area = "Admin"});
			}
			else
			{
				foreach (var item in validationResult.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
				return View();
			}
		}
		[HttpGet]
		public IActionResult EditGuide(int id)
		{
			var values = _guideService.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditGuide(Guide guide)
		{
			_guideService.TUpdate(guide);
			return RedirectToAction("Index");
		}
		public IActionResult ChangeToTrue(int id)
		{
			_guideService.TChangeToTrueByGuide(id);
			return RedirectToAction("Index");
		}
		public IActionResult ChangeToFalse(int id)
		{
			_guideService.TChangeToFalseByGuide(id);
			return RedirectToAction("Index");
		}
	}
}
