﻿using DataAccessLayer.Concrete;
using MediatR;
using SeyehatCoreProje.CQRS.Queries.GuideQueries;
using SeyehatCoreProje.CQRS.Results.GuideResults;

namespace SeyehatCoreProje.CQRS.Handlers.GuideHandlers
{
	public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
	{
		private readonly Context _context;

		public GetGuideByIDQueryHandler(Context context)
		{
			_context=context;
		}

		public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
		{
			var values = await _context.Guides.FindAsync(request.Id);
			return new GetGuideByIDQueryResult
			{
				GuideID = values.GuideID,
				Description= values.Description,
				Name = values.Name
			};
		}
	}
}
