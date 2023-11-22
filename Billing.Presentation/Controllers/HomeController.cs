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
using System.Data;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Drawing.Layout;
using System.Collections.Generic;
using PdfSharp.Fonts;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;
using PdfSharp.Charting;


namespace Billing.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
     //   Uri baseAddress = new Uri("http://localhost:36942/api");
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
           // _httpClient.BaseAddress = baseAddress;
            _logger = logger;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
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

        [HttpPost]
        public async Task<IActionResult> AddSale([FromBody] List<SalesDetails> salesDetailsList)
        {
            //string apiUrl = _apiUrl + "Sales/";// "http://localhost:36942/api/Sales/";
            string apiUrl= "http://localhost:36942/api/Sales/";
            // Process the list of SalesDetails objects
            foreach (var salesDetails in salesDetailsList)
            {
                var json = JsonConvert.SerializeObject(salesDetails);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.PostAsync("AddSales", data);
                    if (response.IsSuccessStatusCode)
                    {
                       // return View();
                    }


                }
            }

            return Json("");
        }

        
    }
}
