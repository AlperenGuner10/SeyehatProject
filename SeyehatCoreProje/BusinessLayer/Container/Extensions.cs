﻿using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules;
using BusinessLayer.ValidationRules.ContactUs;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
	public static class Extensions
	{
		public static void ContainerDependencies(this IServiceCollection services)
		{
			services.AddScoped<ICommentService, CommentManager>();
			services.AddScoped<ICommentDal, EfCommentDal>();

			services.AddScoped<IDestinationService, DestinationManager>();
			services.AddScoped<IDestinationDal, EfDestinationDal>();

			services.AddScoped<IAppUserService, AppUserManager>();
			services.AddScoped<IAppUserDal, EfAppUserDal>();

			services.AddScoped<IReservationService, ReservationManager>();
			services.AddScoped<IReservationDal, EfReservationDal>();

			services.AddScoped<IGuideService, GuideManager>();
			services.AddScoped<IGuideDal, EfGuideDal>();

			services.AddScoped<IExcelService, ExcelManager>();
			services.AddScoped<IPdfService, PdfManager>();

			services.AddScoped<IContactUsService, ContactUsManager>();
			services.AddScoped<IContactUsDal, EfContactUsDal>();

			services.AddScoped<IAnnouncementService, AnnouncementManager>();
			services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

			services.AddScoped<IAccountService, AccountManager>();
			services.AddScoped<IAccountDal, EfAccountDal>();

			services.AddScoped<IUowDal, UowDal>();
		}

		public static void CustomValidator(this IServiceCollection services)
		{
			services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();
			services.AddTransient<IValidator<SendMessageDto>,SendContactUsValidator>();
		}
	}
}
