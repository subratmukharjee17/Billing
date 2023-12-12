using Billing.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace Billing.Presentation.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult AddProduct()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
        public async Task<IActionResult> GetSalesData(string FromDate, string ToDate, string ReportBy)
        {

			//DateTime fromDate = DateTime.ParseExact(FromDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
			//DateTime toDate = DateTime.ParseExact(ToDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

			string apiUrl = "http://localhost:36942/api/Sales/GetSalesDataByParameters";

			apiUrl += $"?fromdate={FromDate}&todate={ToDate}&period={ReportBy}";

			//string apiUrl = "http://localhost:36942/api/Sales/GetAll";
			// User user = new User();

			using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                   // var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    var salesData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesDetails>>(data);

                    // Pass the sales data to the view
                    return Json(salesData);
                }

            }
            return View();

        }
        public async Task<IActionResult> GetSalesReport(string FromDate, string ToDate, string ReportBy,  string reportType)
        {
            string apiUrl = "http://localhost:36942/api/Sales/GetSalesDataByParameters";

            apiUrl += $"?fromdate={FromDate}&todate={ToDate}&period={ReportBy}";
          //  string apiUrl = "http://localhost:36942/api/Sales/GetAll";
            // User user = new User();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    var salesData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SalesDetails>>(data);
                    if (reportType=="PDF")
                    {
                       // return ExportToPdf(table);
                    }
                    else
                    {
                        return  ExportToExcel(salesData);
                    }


                }


            }
            return View();
        }

        public IActionResult ExportToExcel(List<SalesDetails> salesData)
        {
            var excelContent = GenerateExcelContent(salesData);

            // Return the Excel file as a response
            var result = new FileContentResult(excelContent, "application/vnd.ms-excel")
            {
                FileDownloadName = "SalesData.xls"
            };

            return result;
        }

        private byte[] GenerateExcelContent(List<SalesDetails> data)
        {
            var excelContent = new StringBuilder();

            // Excel header
            excelContent.AppendLine("<?xml version=\"1.0\"?>");
            excelContent.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
            excelContent.AppendLine("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
            excelContent.AppendLine("<Worksheet ss:Name=\"Sheet1\">");
            excelContent.AppendLine("<Table>");

            // Get property names from the type of the first data item
            var propertyNames = typeof(SalesDetails).GetProperties()
                                                    .Select(property => property.Name)
                                                    .ToList();

            // Add column headers dynamically
            excelContent.AppendLine("<Row>");
            foreach (var propertyName in propertyNames)
            {
                excelContent.AppendLine($"<Cell><Data ss:Type=\"String\">{propertyName}</Data></Cell>");
            }
            excelContent.AppendLine("</Row>");

            // Add data rows
            foreach (var item in data)
            {
                excelContent.AppendLine("<Row>");
                foreach (var propertyName in propertyNames)
                {
                    // Use reflection to get property value dynamically
                    var propertyValue = item.GetType().GetProperty(propertyName)?.GetValue(item);
                    excelContent.AppendLine($"<Cell><Data ss:Type=\"String\">{propertyValue}</Data></Cell>");
                }
                excelContent.AppendLine("</Row>");
            }

            // Excel footer
            excelContent.AppendLine("</Table>");
            excelContent.AppendLine("</Worksheet>");
            excelContent.AppendLine("</Workbook>");

            // Convert the Excel content to a byte array
            var encoding = new UTF8Encoding();
            var excelBytes = encoding.GetBytes(excelContent.ToString());

            return excelBytes;
        }

        //public IActionResult ExportToExcel(List<SalesDetails> salesData)
        //{
        //    var excelContent = new StringBuilder();

        //    // Excel header
        //    excelContent.AppendLine("<?xml version=\"1.0\"?>");
        //    excelContent.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        //    excelContent.AppendLine("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
        //    excelContent.AppendLine("<Worksheet ss:Name=\"Sheet1\">");
        //    excelContent.AppendLine("<Table>");

        //    // Get property names from the type of the first data item
        //    var propertyNames = typeof(SalesDetails).GetProperties()
        //                                            .Select(property => property.Name)
        //                                            .ToList();

        //    // Add column headers dynamically
        //    excelContent.AppendLine("<Row>");
        //    foreach (var propertyName in propertyNames)
        //    {
        //        excelContent.AppendLine($"<Cell><Data ss:Type=\"String\">{propertyName}</Data></Cell>");
        //    }
        //    excelContent.AppendLine("</Row>");

        //    // Add data rows
        //    foreach (var item in salesData)
        //    {
        //        excelContent.AppendLine("<Row>");
        //        foreach (var propertyName in propertyNames)
        //        {
        //            // Use reflection to get property value dynamically
        //            var propertyValue = item.GetType().GetProperty(propertyName)?.GetValue(item);
        //            excelContent.AppendLine($"<Cell><Data ss:Type=\"String\">{propertyValue}</Data></Cell>");
        //        }
        //        excelContent.AppendLine("</Row>");
        //    }

        //    // Excel footer
        //    excelContent.AppendLine("</Table>");
        //    excelContent.AppendLine("</Worksheet>");
        //    excelContent.AppendLine("</Workbook>");

        //    // Convert the Excel content to a byte array
        //    var encoding = new UTF8Encoding();
        //    var excelBytes = encoding.GetBytes(excelContent.ToString());

        //    // Return the Excel file as a response
        //    return File(excelBytes, "application/vnd.ms-excel", "SalesData.xls");
        //}


        //public ActionResult ExportToExcel(SalesDetails salesdata)
        //{

        //    var data = salesdata;// Enumerable.Empty<SalesDetails>();

        //    // var data = db.MHEPLSCMDatas.Where(x => x.UploadDate == Fdt).ToList();         
        //    string location = "SalesReport";
        //    string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        //    string extension = ".xls";
        //    string filename = $"{location}_{currentDateTime}{extension}";


        //    var salesDetailsList = new List<SalesDetails>();

        //    foreach (DataRow row in salesdata.Rows)
        //    {
        //        var salesDetails = new SalesDetails
        //        {
        //            BillingId = Convert.ToInt16(row["BillingId"]),
        //            ProductId = Convert.ToInt16(row["ProductId"]),
        //            Quantity = Convert.ToDecimal(row["Quantity"]),
        //            Amount = Convert.ToDecimal(row["Amount"])
        //        };

        //        salesDetailsList.Add(salesDetails);
        //    }
        //    // Create the Excel file
        //    var fileContents = GenerateExcelFile(salesDetailsList);

        //    // Return the file as a response
        //    var result = new FileContentResult(fileContents, "application/vnd.ms-excel")
        //    {
        //        FileDownloadName = filename
        //        //FileDownloadName = "testing1234.xls"
        //    };

        //    return result;

        //}



        //private byte[] GenerateExcelFile(IEnumerable<SalesDetails> data)
        //{
        //    //public  ActionResult GenerateExcelFile(IEnumerable<SalesDetails> data)
        //    //{
        //    var excelContent = new StringBuilder();

        //    excelContent.AppendLine("<?xml version=\"1.0\"?>");
        //    excelContent.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        //    excelContent.AppendLine("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
        //    excelContent.AppendLine("<Worksheet ss:Name=\"Sheet1\">");
        //    excelContent.AppendLine("<Table>");

        //    // Get property names from the type of the first data item
        //    var propertyNames = typeof(SalesDetails).GetProperties()
        //                                            .Select(property => property.Name)
        //                                            .ToList();

        //    // Add column headers dynamically
        //    excelContent.AppendLine("<Row>");
        //    foreach (var propertyName in propertyNames)
        //    {
        //        excelContent.AppendLine($"<Cell><Data ss:Type=\"String\">{propertyName}</Data></Cell>");
        //    }
        //    excelContent.AppendLine("</Row>");

        //    // Add data rows
        //    foreach (var item in data)
        //    {
        //        excelContent.AppendLine("<Row>");
        //        foreach (var propertyName in propertyNames)
        //        {
        //            // Use reflection to get property value dynamically
        //            var propertyValue = item.GetType().GetProperty(propertyName)?.GetValue(item);
        //            excelContent.AppendLine($"<Cell><Data ss:Type=\"String\">{propertyValue}</Data></Cell>");
        //        }
        //        excelContent.AppendLine("</Row>");
        //    }

        //    excelContent.AppendLine("</Table>");
        //    excelContent.AppendLine("</Worksheet>");
        //    excelContent.AppendLine("</Workbook>");

        //    // Convert the Excel content to a byte array
        //    var encoding = new UTF8Encoding();
        //    var excelBytes = encoding.GetBytes(excelContent.ToString());

        //    return excelBytes;

        //    //var result = new FileContentResult(excelBytes, "application/vnd.ms-excel")
        //    //{
        //    //   // FileDownloadName = filename
        //    //    FileDownloadName = "testing1234.xls"
        //    //};

        //    //return result;
        //}

        //public ActionResult ExportToPdf(DataTable salesdata)
        //{
        //    var salesDetailsList = new List<SalesDetails>();

        //    foreach (DataRow row in salesdata.Rows)
        //    {
        //        var salesDetails = new SalesDetails
        //        {
        //            //BillNo = Convert.ToInt64(row["BillNo"]),
        //            //ProductId = Convert.ToInt16(row["ProductId"]),
        //            //Quantity = Convert.ToDecimal(row["Quantity"]),
        //            //Amount = Convert.ToDecimal(row["Amount"])

        //        };

        //        salesDetailsList.Add(salesDetails);
        //    }
        //    var fileContents = GeneratePdf(salesDetailsList);

        //    string location = "SalesReport";
        //    string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        //    string extension = ".pdf";
        //    string filename = $"{location}_{currentDateTime}{extension}";

        //    var result = new FileContentResult(fileContents, "application/pdf")
        //    {
        //        FileDownloadName = filename
        //    };

        //    return result;
        //}

        //public static byte[] GeneratePdf(IEnumerable<SalesDetails> data)
        //{
        //    var document = new PdfDocument();
        //    var page = document.AddPage();
        //    var gfx = XGraphics.FromPdfPage(page);
        //    GlobalFontSettings.FontResolver = new CustomFontResolver();

        //    XFont font = new XFont("Verdana", 12);
        //    //   var font = new MigraDoc.DocumentObjectModel.Font("Verdana", 12);
        //    // font.Bold = true;
        //    int y = 40;

        //    // Add column headers dynamically
        //    foreach (var property in typeof(SalesDetails).GetProperties())
        //    {
        //        gfx.DrawString(property.Name, font, XBrushes.Black, new XRect(40, y, 200, 20), XStringFormats.TopLeft);
        //        y += 20;
        //    }

        //    // Add data rows
        //    foreach (var item in data)
        //    {
        //        y += 20;

        //        foreach (var property in typeof(SalesDetails).GetProperties())
        //        {
        //            var value = property.GetValue(item)?.ToString() ?? "N/A";
        //            gfx.DrawString(value, font, XBrushes.Black, new XRect(40, y, 200, 20), XStringFormats.TopLeft);
        //            y += 20;
        //        }
        //    }

        //    // Save the document to a memory stream
        //    var pdfStream = new System.IO.MemoryStream();
        //    document.Save(pdfStream, false);
        //    return pdfStream.ToArray();

        //}

    }
}
