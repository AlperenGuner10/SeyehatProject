using MediatR;
using SeyehatCoreProje.CQRS.Results.GuideResults;

namespace SeyehatCoreProje.CQRS.Queries.GuideQueries
{
	public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
	{

	}
}
