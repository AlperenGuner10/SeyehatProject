using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using SeyehatCoreProje.Areas.Admin.Models;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IMapper _mapper;

		public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
		{
			_announcementService=announcementService;
			_mapper=mapper;
		}

		public IActionResult Index()
		{
			var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.GetAll());
			return View(values);
		}
		[HttpGet]
		public IActionResult AddAnnouncement()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddAnnouncement(AnnouncementAddDto announcement)
		{
			if (ModelState.IsValid)
			{
				_announcementService.TAdd(new Announcement()
				{
					Content = announcement.Content,
					Title = announcement.Title,
					Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction("Index", "Announcement", new { area = "Admin" });
			}
			return View(announcement);
		}
		public IActionResult DeleteAnnouncement(int id)
		{
			var values = _announcementService.TGetById(id);
			_announcementService.TRemove(values);
			return RedirectToAction("Index", "Announcement", new { area = "Admin" });
		}
		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)
		{
			var values = _mapper.Map<AnnouncementUpdateDto>(_announcementService.TGetById(id));
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateAnnouncement(AnnouncementUpdateDto update)
		{
			if (ModelState.IsValid)
			{
				_announcementService.TUpdate(new Announcement
				{
					AnnouncementID = update.AnnouncementId,
					Title = update.Title,
					Content = update.Content,
					Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
				});
				return RedirectToAction("Index", "Announcement", new { area = "Admin" });
			}
			return View(update);
		}
	}
}
