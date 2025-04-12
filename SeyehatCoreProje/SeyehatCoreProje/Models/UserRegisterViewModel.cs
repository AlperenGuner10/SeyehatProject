using System.ComponentModel.DataAnnotations;

namespace SeyehatCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen adınızı giriniz.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
		public string Surname { get; set; }


		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
		public string Username { get; set; }


		[Required(ErrorMessage = "Lütfen Mail adresinizi giriniz.")]
		public string Mail { get; set; }


		[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifreyi tekrar giriniz.")]
		[Compare("Password",ErrorMessage ="Lütfen şifrelerinizi aynı giriniz")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Lütfen cinsiyetinizi seçiniz.")]
		public string Gender { get; set; } 
	}
}
