﻿using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x=>x.Name).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
			RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
			RuleFor(x=>x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
			RuleFor(x=>x.Username).NotEmpty().WithMessage("Kullanıcı Adı Alanı Boş Geçilemez");
			RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
			RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrarı Alanı Boş Geçilemez");
			RuleFor(x => x.Username).MaximumLength(15).WithMessage("Lütfen en fazla 15 karakter girişi yapınız");
			RuleFor(x=>x.Password).Equal(y=>y.ConfirmPassword).WithMessage("Şifreler Biribirleriyle Uyuşmuyor.");
		}
	}
}
