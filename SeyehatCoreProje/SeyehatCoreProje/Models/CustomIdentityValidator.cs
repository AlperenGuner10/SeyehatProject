using Microsoft.AspNetCore.Identity;

namespace SeyehatCoreProje.Models
{
	public class CustomIdentityValidator : IdentityErrorDescriber //kullanıcı şifresini belirlerken kullanması gereken karakterleri göstermek için hazırlanan sınıf 
	{
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code="PasswordRequiresDigit",
				Description="Parolada en az 1 adet rakam gereklidir."
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"Şifre en az {length} karakter olmalıdır."
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code ="PasswordRequiresUpper",
				Description ="Parola en az 1 adet büyük karakter içermelidir."
			};
		}
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code ="PasswordRequiresLower",
				Description ="Parola en az 1 adet küçük karakter içermelidir."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code ="PasswordRequiresNonAlphanumeric",
				Description ="Parola en az 1 adet sembol karakter içermelidir."
			};
		}		
	}
}
