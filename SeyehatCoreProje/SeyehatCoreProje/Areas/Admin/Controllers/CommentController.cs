﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class CommentController : Controller
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService=commentService;
		}

		public IActionResult Index()
		{
			var values = _commentService.TGetListCommentWithDestination();
			return View(values);
		}
		public IActionResult DeleteComment(int id)
		{
			var values = _commentService.TGetById(id);
			_commentService.TRemove(values);
			return RedirectToAction("Index");
		}
	}
}
