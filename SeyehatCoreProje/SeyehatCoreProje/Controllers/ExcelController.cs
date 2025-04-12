﻿using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SeyehatCoreProje.Models;

namespace SeyehatCoreProje.Controllers
{
	public class ExcelController : Controller
	{
		private readonly IExcelService _excelService;

		public ExcelController(IExcelService excelService)
		{
			_excelService=excelService;
		}

		public IActionResult Index()
		{
			return View();
		}
		public List<DestinationModel> DestinationList()
		{
			List<DestinationModel> destinationModels = new List<DestinationModel>();
			using (var cnt = new Context())
			{
				destinationModels = cnt.Destinations.Select(x => new DestinationModel
				{
					City = x.City,
					DailyDay = x.DailyDay,
					Price = x.Price,
					Capacity = x.Capacity
				}).ToList();
			}
			return destinationModels;
		}

		public IActionResult StaticExcelReport()
		{
			return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
		}

		public IActionResult DestinationExcelReport()
		{
			using (var workbook = new XLWorkbook())
			{
				var worksheet = workbook.Worksheets.Add("Tur Listesi");
				worksheet.Cell(1, 1).Value ="Şehir";
				worksheet.Cell(1, 2).Value ="Tatil Süresi";
				worksheet.Cell(1, 3).Value ="Fiyat";
				worksheet.Cell(1, 4).Value ="Kapasite";

				int rowCount = 2;
				foreach (var item in DestinationList())
				{
					worksheet.Cell(rowCount, 1).Value = item.City;
					worksheet.Cell(rowCount, 2).Value=item.DailyDay;
					worksheet.Cell(rowCount, 3).Value=item.Price;
					worksheet.Cell(rowCount, 4).Value=item.Capacity;
					rowCount++;
				}
				using(var stream = new MemoryStream())
				{
					workbook.SaveAs(stream);
					var content = stream.ToArray();
					return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
				}
			}
		}
	}
}
