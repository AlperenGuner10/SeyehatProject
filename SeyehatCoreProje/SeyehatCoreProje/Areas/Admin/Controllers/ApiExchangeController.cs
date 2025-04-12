using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SeyehatCoreProje.Areas.Admin.Models;
using System.Net.Http.Headers;


namespace SeyehatCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class ApiExchangeController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<BookingExchangeViewModel2> bookingExchangeViewModels = new List<BookingExchangeViewModel2>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
				Headers =
	{
		{ "x-rapidapi-key", "2c9f58bd85mshff4fd960ca2c21ep13b44djsn90e0cb74dc50" },
		{ "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<BookingExchangeViewModel2>(body);
				return View(values.data.exchange_rates);
			}
		}
	}
}
