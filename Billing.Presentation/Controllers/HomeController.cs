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
            string apiUrl = "http://localhost:36942/api/Menu/GetAllMenus";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            var responseContent = await response.Content.ReadAsStringAsync();
            var menu = (List<MainMenu>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent, typeof(List<MainMenu>));


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

		
		

	}
}
