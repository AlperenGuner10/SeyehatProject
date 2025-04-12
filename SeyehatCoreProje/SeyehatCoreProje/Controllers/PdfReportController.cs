using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace SeyehatCoreProje.Controllers
{
	public class PdfReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult StaticPdfReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfRaporları/"+"dosya1.pdf");
			var stream = new FileStream(path, FileMode.Create);

			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();

			Paragraph paragraph = new Paragraph("Seyehat Rezervasyon Pdf Raporu");
			document.Add(paragraph);
			document.Close();
			return File("/pdfRaporları/dosya1.pdf", "application/pdf", "dosya1.pdf");

		}
		public IActionResult StaticCustomerReport()
		{
			string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfRaporları/"+"dosya2.pdf");
			var stream = new FileStream(path, FileMode.Create);

			Document document = new Document(PageSize.A4);
			PdfWriter.GetInstance(document, stream);

			document.Open();

			PdfPTable pdfPTable = new PdfPTable(3);
			pdfPTable.AddCell("Misafir Adı");
			pdfPTable.AddCell("Misafir Soyadı");
			pdfPTable.AddCell("Misafir TC");

			pdfPTable.AddCell("Sema");
			pdfPTable.AddCell("Demir");
			pdfPTable.AddCell("55252515151");

			pdfPTable.AddCell("Cihan");
			pdfPTable.AddCell("Albora");
			pdfPTable.AddCell("611616561161");

			pdfPTable.AddCell("Mahir");
			pdfPTable.AddCell("Gümüş");
			pdfPTable.AddCell("123165846564");

			document.Add(pdfPTable);
			document.Close();
			return File("/pdfRaporları/dosya2.pdf", "application/pdf", "dosya2.pdf");
		}
	}
}
