using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.CQRS.Commands.GuideCommands;
using SeyehatCoreProje.CQRS.Queries.GuideQueries;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GuideMediatRController : Controller
	{
		private readonly IMediator _mediator;

		public GuideMediatRController(IMediator mediator)
		{
			_mediator=mediator;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _mediator.Send(new GetAllGuideQuery());
			return View(values);
		}
		[HttpGet]
		public async Task<IActionResult> GetGuide(int id)
		{
			var values = await _mediator.Send(new GetGuideByIDQuery(id));
			return View(values);
		}
		[HttpGet]
		public IActionResult AddGuide()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddGuide(CreateGuideComment guideComment)
		{
			await _mediator.Send(guideComment);
			return RedirectToAction("Index");
		}
	}
}
