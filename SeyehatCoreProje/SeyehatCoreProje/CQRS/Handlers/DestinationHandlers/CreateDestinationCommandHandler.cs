using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using SeyehatCoreProje.CQRS.Commands.DestinationCommands;

namespace SeyehatCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class CreateDestinationCommandHandler
	{
		private readonly Context _context;

		public CreateDestinationCommandHandler(Context context)
		{
			_context=context;
		}
		public void Handle(CreateDestinationCommand command)//cqrs ekleme işlemi
		{
			_context.Destinations.Add(new Destination
			{
				City = command.City,
				Price = command.Price,
				DailyDay = command.DailyDay,
				Capacity = command.Capacity,
				Status =  true
			});
			_context.SaveChanges();
		}
	}
}
