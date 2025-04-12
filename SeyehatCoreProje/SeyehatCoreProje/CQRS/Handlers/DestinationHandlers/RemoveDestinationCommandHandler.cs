using DataAccessLayer.Concrete;
using SeyehatCoreProje.CQRS.Commands.DestinationCommands;

namespace SeyehatCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class RemoveDestinationCommandHandler
	{
		private readonly Context _context;

		public RemoveDestinationCommandHandler(Context context)
		{
			_context=context;
		}
		public void Handle(RemoveDestinatonCommand command)
		{
			var values = _context.Destinations.Find(command.ID);
			_context.Destinations.Remove(values);
			_context.SaveChanges();
		}
	}
}
