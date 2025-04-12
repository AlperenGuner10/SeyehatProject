using MediatR;
using SeyehatCoreProje.CQRS.Results.GuideResults;

namespace SeyehatCoreProje.CQRS.Queries.GuideQueries
{
	public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
	{
		public GetGuideByIDQuery(int id)
		{
			Id=id;
		}

		public int Id { get; set; }
	}
}
