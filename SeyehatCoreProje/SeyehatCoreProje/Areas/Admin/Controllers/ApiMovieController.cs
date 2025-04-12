using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyehatCoreProje.Areas.Admin.Models;

namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class ApiMovieController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<ApiMovieViewModel> apiMovieViewModels = new List<ApiMovieViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "x-rapidapi-key", "2c9f58bd85mshff4fd960ca2c21ep13b44djsn90e0cb74dc50" },
		{ "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovieViewModels = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
				return View(apiMovieViewModels);
			}
		}
	}
}
