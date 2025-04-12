using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AboutValidator : AbstractValidator<About>
	{
		public AboutValidator()
		{
			RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama kısmını boş geçemezsiniz...!");//Fluent Validation
			RuleFor(x=>x.Description).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama bilgisini giriniz...!");
			RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel seçiniz");
			RuleFor(x => x.Description).MaximumLength(1500).WithMessage("Lütfen açıklama karakter sayısı 1500'ü geçmesin");
		}
	}
}
