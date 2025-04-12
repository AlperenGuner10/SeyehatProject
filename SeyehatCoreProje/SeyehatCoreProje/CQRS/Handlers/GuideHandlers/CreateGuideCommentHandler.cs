using DataAccessLayer.Concrete;
using MediatR;
using SeyehatCoreProje.CQRS.Commands.GuideCommands;

namespace SeyehatCoreProje.CQRS.Handlers.GuideHandlers
{
	public class CreateGuideCommentHandler : IRequestHandler<CreateGuideComment>
	{
		private readonly Context _context;

		public CreateGuideCommentHandler(Context context)
		{
			_context=context;
		}

		public async Task<Unit> Handle(CreateGuideComment request, CancellationToken cancellationToken)
		{
			_context.Guides.Add(new EntityLayer.Concrete.Guide
			{
				Name = request.Name,
				Description = request.Description,
				Status = true
			});
			await _context.SaveChangesAsync();
			return Unit.Value;
		}
	}
}
