namespace SeyehatCoreProje.Models
{
	public class MailRequest
	{
		public string Name { get; set; }//Gönderen kişi Maili
		public string SenderMail { get; set; }//Gönderen kişi Maili
		public string RecieverMail { get; set; }//Alıcı kişi Maili
		public string Subject { get; set; }//Konu
		public string Body { get; set; }//Açıklama
	}
}
