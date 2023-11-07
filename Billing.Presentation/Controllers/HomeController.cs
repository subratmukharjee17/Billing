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
                string apiUrl = "http://localhost:36942/api/Sales/";
                User user = new User();

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
        public async Task<IActionResult> GetSalesReport()
        {
            return View();
        }
    }
}