using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.ViewComponents.Default
{
	public class _Testimonial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());
			var result = _testimonialManager.GetAll();
			return View(result);
		}
	}
}
