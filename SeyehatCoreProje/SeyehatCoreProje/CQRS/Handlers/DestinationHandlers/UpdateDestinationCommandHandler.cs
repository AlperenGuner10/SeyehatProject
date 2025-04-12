using DataAccessLayer.Concrete;
using SeyehatCoreProje.CQRS.Commands.DestinationCommands;

namespace SeyehatCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class UpdateDestinationCommandHandler
	{
		private readonly Context _context;

		public UpdateDestinationCommandHandler(Context context)
		{
			_context=context;
		}
		public void Handle(UpdateDestinationCommand commandHandler)
		{
			var values = _context.Destinations.Find(commandHandler.Destinationid);
			values.City = commandHandler.City;
			values.DailyDay = commandHandler.DailyDay;
			values.Price = commandHandler.Price;
			_context.SaveChanges();
		}
	}
}
