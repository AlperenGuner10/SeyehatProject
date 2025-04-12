using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeyehatApiProject.DAL.Context;
using SeyehatApiProject.DAL.Entities;

namespace SeyehatApiProject.Controllers
{
	[EnableCors]
	[Route("api/[controller]")]
	[ApiController]
	public class VisitorController : ControllerBase
	{
		[HttpGet]
		public IActionResult VisitorList()
		{
			using (var context = new VisitorContext())
			{
				var values = context.Visitors.ToList();
				return Ok(values);
			}
		}
		[HttpPost]
		public IActionResult VisitorAdd(Visitor visitor)
		{
			using(var context = new VisitorContext())
			{
				context.Add(visitor);
				context.SaveChanges();
				return Ok();
			}
		}
		[HttpGet("{id}")]
		public IActionResult VisitorGet(int id)
		{
			using( var context = new VisitorContext())
			{
				var values = context.Visitors.Find(id);
				if (values == null)
				{
					return NotFound();
				}
				else
				{
					return Ok(values);
				}
			}
		}
		[HttpDelete("{id}")]
		public IActionResult VisitorDelete(int id)
		{
			using(var context = new VisitorContext())
			{
				var values = context.Visitors.Find(id);
				if(values == null)
				{
					return NotFound();
				}
				else
				{
					context.Remove(values);
					context.SaveChanges();
					return Ok();
				}
			}
		}
		[HttpPut]
		public IActionResult VisitorUpdate(Visitor visitor)
		{
			using (var context = new VisitorContext())
			{
				var values = context.Visitors.Find(visitor.VisitorID);
				if (values == null)
				{
					return NotFound();
				}
				else
				{
					values.City = visitor.City;
					values.Name = visitor.Name;
					values.Country = visitor.Country;
					values.Surname = visitor.Surname;
					values.Mail = visitor.Mail;
					context.Update(values);
					context.SaveChanges();
					return Ok();
				}
			}
		}

	}
}
