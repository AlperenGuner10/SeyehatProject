using MediatR;

namespace SeyehatCoreProje.CQRS.Commands.GuideCommands
{
	public class CreateGuideComment : IRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
