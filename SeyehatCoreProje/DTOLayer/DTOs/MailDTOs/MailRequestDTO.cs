using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.MailDTOs
{
	public class MailRequestDTO
	{
		public string Name { get; set; }//Gönderen kişi Maili
		public string SenderMail { get; set; }//Gönderen kişi Maili
		public string RecieverMail { get; set; }//Alıcı kişi Maili
		public string Subject { get; set; }//Konu
		public string Body { get; set; }//Açıklama
	}
}
