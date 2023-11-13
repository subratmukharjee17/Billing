using Billing.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml.Linq;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using static System.Net.WebRequestMethods;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace Billing.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            //string apiUrl = "http://localhost:36942/api/Menu/GetAllMenus";
            //User user = new User();

            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(apiUrl);
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    HttpResponseMessage response = await client.GetAsync(apiUrl);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsStringAsync();
            //        var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
            //    }


            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        

        public IActionResult Sales()
        {
            return View();
        }

        //public async Task<IActionResult> AddSale(string customerName,string Address,long phone,decimal weight,decimal rate,decimal amount,string Pname)
        //{
        //    try
        //    {
        //       // var salesDto = new SalesDto(); 


        //        //salesDto.CustomerName = customerName;
        //        //salesDto.CustomerAddress = Address;
        //        //salesDto.CustomerPhNo = phone;
        //        //salesDto.ProductName = Pname;
        //        //salesDto.ProductWeight= weight;
        //        //salesDto.Amount = amount;
        //        //salesDto.ProductRate = rate;
        //        var salesDto = new SalesDto
        //        {
        //            CustomerName = customerName,
        //            CustomerAddress = Address,
        //            CustomerPhNo = phone,
        //            ProductName = Pname,
        //            ProductWeight = weight,
        //            Amount = amount,
        //            ProductRate = rate
        //        };
        //        var client = _clientFactory.CreateClient();
        //        client.BaseAddress = new Uri("http://localhost:36942/api/Sales/"); // Your API base URL

        //        var json = JsonConvert.SerializeObject(salesDto);
        //        var data = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await client.PostAsync("AddSales", data);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            // Handle success
        //            return View();
        //        }
        //        else
        //        {
        //            // Handle failure
        //            return View("Error");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exception
        //        return View("Error");
        //    }
        //}

        public async Task<IActionResult> AddSale(string customerName, string Address, long phone, decimal weight, decimal rate, decimal amount, string Pname)
        {
            try
            {
                  // var salesDto = new SalesDto(); 


                  //salesDto.CustomerName = customerName;
                  //salesDto.CustomerAddress = Address;
                  //salesDto.CustomerPhNo = phone;
                  //salesDto.ProductName = Pname;
                  //salesDto.ProductWeight= weight;
                  //salesDto.Amount = amount;
                  //salesDto.ProductRate = rate;
                  var salesDto = new SalesDetails
                {
                    CustomerName = customerName,
                    CustomerAddress = Address,
                    CustomerPhNo = phone,
                    ProductName = Pname,
                    ProductWeight = weight,
                    Amount = amount,
                    ProductRate = rate
                };
                //var client = _clientFactory.CreateClient();
                //client.BaseAddress = new Uri("http://localhost:36942/api/Sales/"); // Your API base URL

                var json = JsonConvert.SerializeObject(salesDto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

              
                ///////////////
                ///
               // string apiUrl = "http://localhost:1010/api/Sales/";
                string apiUrl = "http://localhost:36942/api/Sales/";

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //  HttpResponseMessage response = await client.GetAsync(apiUrl);
                    var response = await client.PostAsync("AddSales", data);
                    if (response.IsSuccessStatusCode)
                    {
                        return View();
                        //  var data = await response.Content.ReadAsStringAsync();
                        //  var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                    }


                }
                return View();

                /////////////




                //if (response.IsSuccessStatusCode)
                //{
                //    // Handle success
                //    return View();
                //}
                //else
                //{
                //    // Handle failure
                //    return View("Error");
                //}
            }
            
            catch (Exception ex)
            {
                // Handle exception
                return View("Error");
            }
        }
        public async Task<IActionResult> SalesReport()
        {
                 

            return View();
         
        }
        public async Task<IActionResult> GetSalesReport(string startDate,string endDate,string dateRange)
        {
            string apiUrl = "http://localhost:1010/api/Sales/GetAll";
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
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                }


            }
            return View();
        }

        public ActionResult ExportToExcel(string date)
        {
           
            var data = Enumerable.Empty<SalesDetails>();
            if (!string.IsNullOrEmpty(date))
            {
                DateTime? Fdt = Convert.ToDateTime(date).Date;
                int selectedYear = Fdt.Value.Year;
                int selectedMonth = Fdt.Value.Month;
              //  data = db.MHEPLSCMDatas.Where(x => x.UploadDate.Month == selectedMonth && x.UploadDate.Year == selectedYear && x.Source == "SAP").ToList();
            }

            // var data = db.MHEPLSCMDatas.Where(x => x.UploadDate == Fdt).ToList();         
            string location = "SalesReport";
            string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string extension = ".xls";
            string filename = $"{location}_{currentDateTime}{extension}";
            // Create the Excel file
            var fileContents = GenerateExcelFile(data);

            // Return the file as a response
            var result = new FileContentResult(fileContents, "application/vnd.ms-excel")
            {
                FileDownloadName = filename
                //FileDownloadName = "testing1234.xls"
            };

            return result;

        }



        private byte[] GenerateExcelFile(IEnumerable<SalesDetails> data)
        {
            var excelContent = new StringBuilder();

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

            excelContent.AppendLine("</Table>");
            excelContent.AppendLine("</Worksheet>");
            excelContent.AppendLine("</Workbook>");

            // Convert the Excel content to a byte array
            var encoding = new UTF8Encoding();
            var excelBytes = encoding.GetBytes(excelContent.ToString());

            return excelBytes;
        }

        public ActionResult ExportToPdf()
        {
            // Get your data from the database or another source
            List<string> data = GetData();

            // Create a PDF document
            byte[] pdfBytes = GeneratePdf(data);

            // Return the PDF file to the client
            return File(pdfBytes, "application/pdf", "ExportedData.pdf");
        }

        private List<string> GetData()
        {
            // Replace this with your data retrieval logic
            return new List<string> { "Data 1", "Data 2", "Data 3" };
        }

        private byte[] GeneratePdf(List<string> data)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                var writer = new PdfWriter(stream);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);

                // Add data to the PDF
                foreach (var item in data)
                {
                    document.Add(new Paragraph(item));
                }

                document.Close();

                return stream.ToArray();
            }
        }
    }
}