using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.CQRS.Queries.DestinationQueries;
using SeyehatCoreProje.CQRS.Results.DestinationResults;

namespace SeyehatCoreProje.CQRS.Handlers.DestinationHandlers
{
	[Area("Admin")]
	public class GetDestinationByIDQueryHandler
	{
		private readonly Context _context;

		public GetDestinationByIDQueryHandler(Context context)
		{
			_context=context;
		}
		public GetDestinationByIDQueryResult Handle(GetDestinationByIdQuery getDestinationByIdQuery)
		{
			var values = _context.Destinations.Find(getDestinationByIdQuery.id);
			return new GetDestinationByIDQueryResult
			{
				Destinationid = values.DestinationId,
				City = values.City,
				DailyDay = values.DailyDay,
				Price = values.Price
			};
		}
	}
}
