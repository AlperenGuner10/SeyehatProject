using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using SeyehatCoreProje.CQRS.Results.DestinationResults;

namespace SeyehatCoreProje.CQRS.Handlers.DestinationHandlers
{
	public class GetAllDestinationQueryHandler
	{
		private readonly Context _context;

		public GetAllDestinationQueryHandler(Context context)
		{
			_context=context;
		}

		public List<GetAllDestinationQueryResult> Handle()
		{
			var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
			{
				id = x.DestinationId,
				capacity = x.Capacity,
				city = x.City,
				dailyday = x.DailyDay,
				price = x.Price
			}).AsNoTracking().ToList();
			return values;
		}
	}
}
