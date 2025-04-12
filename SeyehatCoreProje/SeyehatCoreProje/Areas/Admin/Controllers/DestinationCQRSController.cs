using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.CQRS.Commands.DestinationCommands;
using SeyehatCoreProje.CQRS.Handlers.DestinationHandlers;
using SeyehatCoreProje.CQRS.Queries.DestinationQueries;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DestinationCQRSController : Controller
	{
		private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
		private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
		private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
		private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
		private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

		public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIDQueryHandler getDestinationByIDQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
		{
			_getAllDestinationQueryHandler=getAllDestinationQueryHandler;
			_getDestinationByIDQueryHandler=getDestinationByIDQueryHandler;
			_createDestinationCommandHandler=createDestinationCommandHandler;
			_removeDestinationCommandHandler=removeDestinationCommandHandler;
			_updateDestinationCommandHandler=updateDestinationCommandHandler;
		}

		public IActionResult Index()
		{
			var values = _getAllDestinationQueryHandler.Handle();
			return View(values);
		}
		[HttpGet]
		public IActionResult GetDestination(int id)
		{
			var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIdQuery(id));
			return View(values);
		}
		[HttpPost]
		public IActionResult GetDestination(UpdateDestinationCommand updateDestination)
		{
			_updateDestinationCommandHandler.Handle(updateDestination);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddDestination(CreateDestinationCommand handler)
		{
			_createDestinationCommandHandler.Handle(handler);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteDestination(int id)
		{
			_removeDestinationCommandHandler.Handle(new RemoveDestinatonCommand(id));
			return RedirectToAction("Index");
		}
	}
}
