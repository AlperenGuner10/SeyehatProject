namespace SeyehatCoreProje.CQRS.Commands.DestinationCommands
{
	public class CreateDestinationCommand
	{
		public string City { get; set; }
		public string DailyDay { get; set; }
		public double Price { get; set; }
		public int Capacity { get; set; }
	}
}
