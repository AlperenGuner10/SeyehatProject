namespace SeyehatCoreProje.CQRS.Commands.DestinationCommands
{
	public class RemoveDestinatonCommand
	{
		public RemoveDestinatonCommand(int id)
		{
			ID=id;
		}

		public int ID { get; set; }
	}
}
