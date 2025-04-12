using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeyehatCoreProje.CQRS.Queries.GuideQueries;
using SeyehatCoreProje.CQRS.Results.DestinationResults;
using SeyehatCoreProje.CQRS.Results.GuideResults;

namespace SeyehatCoreProje.CQRS.Handlers.GuideHandlers
{
	public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
	{
		private readonly Context _context;

		public GetAllGuideQueryHandler(Context context)
		{
			_context=context;
		}

		public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
		{
			return await _context.Guides.Select(x => new GetAllGuideQueryResult
			{
				GuideID = x.GuideID,
				Description = x.Description,
				Name = x.Name,
				Image = x.Image
			}).AsNoTracking().ToListAsync();
		}
	}
}
