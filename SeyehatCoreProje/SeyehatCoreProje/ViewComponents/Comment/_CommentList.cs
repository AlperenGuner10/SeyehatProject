using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Comment
{
	public class _CommentList : ViewComponent
	{
		CommentManager _commentManager = new CommentManager(new EfCommentDal());
		Context context = new Context();
		public IViewComponentResult Invoke(int id)
		{
			ViewBag.commentCount = context.Comments.Where(x=>x.DestinationId ==id).Count();
			var values = _commentManager.TGetListCommentWithDestinationAndUser(id);
			return View(values);
		} 
	}
}
