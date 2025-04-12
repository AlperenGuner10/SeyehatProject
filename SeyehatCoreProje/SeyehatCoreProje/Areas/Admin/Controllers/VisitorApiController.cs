using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyehatCoreProje.Areas.Admin.Models;
using System.Text;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class VisitorApiController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public VisitorApiController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory=httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5160/api/Visitor");//swagger get isteğinden aldık
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddVisitor()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddVisitor(VisitorViewModel v)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(v);
			StringContent content = new StringContent(jsonData,Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5160/api/Visitor",content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "VisitorApi", new { area = "Admin" });
			}
			return View();
		}
		public async Task<IActionResult> DeleteVisitor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5160/api/Visitor/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "VisitorApi", new { area = "Admin" });
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateVisitor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5160/api/Visitor/{id}");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateVisitor(VisitorViewModel v)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(v);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5160/api/Visitor", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "VisitorApi", new { area = "Admin" });
			}
			return View();
		}
	}
}
