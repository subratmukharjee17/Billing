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

		public async Task<int> GetMaxBillNO()
		{
			int MaxBillNO = 0;
			string apiUrl = "http://localhost:36942/api/BillingInfo/GetMaxBillingId";
			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();

					MaxBillNO = JsonConvert.DeserializeObject<int>(data);


					//ViewBag.BillNO = MaxBillNO+1;
				}


			}
			return MaxBillNO+1;

		}


		public async Task<IActionResult> Sales()
		{
			int billno = await GetMaxBillNO();
			ViewBag.BillNO=billno;
			string apiUrl = "http://localhost:36942/api/Product/GetAllProducts";

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();

					List<Product> productDetails = JsonConvert.DeserializeObject<List<Product>>(data);
				

					ViewBag.ProductDetails = productDetails;
				}


			}
			return View();
		}

		public async Task<IActionResult> GetProductRate(Int64 productName)
		{
			string apiUrl = "http://localhost:36942/api/Product/GetAllProducts";

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();


					var productList = JsonConvert.DeserializeObject<List<Product>>(data);

					// Find the product by productId
					var product = productList.FirstOrDefault(p => p.ProductId == productName);

					// Check if the product is found
					if (product != null)
					{
						// Get the rate from the found product
						var rate = product.Price;
						return Json(new { Rate = rate });
					}
				}


			}
			return View();
		}

		

		public async Task<IActionResult> AddSale([FromBody] List<SalesDetails> salesDetailsList)
		{
			try
			{
				//int generatedBillingId = 0;
				//if (!ModelState.IsValid)
				//{
				//	// Handle validation errors
				//	return BadRequest(ModelState);
				//}

					// Insert customer and billing info (assuming the first item in the list)
					var firstSalesDetails = salesDetailsList.FirstOrDefault();

				if (firstSalesDetails != null)
				{
					var generatedBillingId1 = await AddCustomerAndBillingInfoToApi(firstSalesDetails);
					var generatedBillingId2 = JsonConvert.DeserializeObject<string>(generatedBillingId1);
				}

				// Insert sales details for each item in the list
				foreach (var salesDetails in salesDetailsList)
				{
					await AddSalesToApi(salesDetails, 1);
				}

				return Json("Sales data added successfully.");
			}
			catch (Exception ex)
			{
				return Json($"Error: {ex.Message}");
			}
		}
		public async Task<string> AddCustomerAndBillingInfoToApi(SalesDetails salesDetails)
		{
			string apiUrl = "http://localhost:36942/api/Sales/";
			var json = JsonConvert.SerializeObject(salesDetails);
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = await client.PostAsync("AddCustomerAndBillingInfo", data);

				// Check the response and handle as needed
				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadAsStringAsync();
					////var responseContent = await response.Content.ReadAsStringAsync();
					//var responseContent = await response.Content.ReadAsStringAsync();
					//if (int.TryParse(responseContent, out int generatedBillingId))
					//{
					//	// Successfully parsed as an integer
					//	return generatedBillingId;
					//}
					//else
					//{
					//	// Handle the case where the response content is not a valid integer
					//	// You may want to log an error or handle it appropriately
					//	return -1; // or any other default value or error code
					//}
					////var generatedBillingId = JsonConvert.DeserializeObject<int>(responseContent);
					////return generatedBillingId;
				}

				return "-1";
			}
		}

		public async Task AddSalesToApi(SalesDetails salesDetails,int BillingID)
		{
			// Make an HTTP request to your API endpoint for sales details
			string apiUrl = "http://localhost:36942/api/Sales/";
			//salesDetails.BillingId = BillingID;
			var json = JsonConvert.SerializeObject(salesDetails); // Adjust serialization as needed
			var data = new StringContent(json, Encoding.UTF8, "application/json");

			using (HttpClient client = new HttpClient())
			{
				client.BaseAddress = new Uri(apiUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage response = await client.PostAsync("AddSales", data);

				// Check the response and handle as needed
				if (response.IsSuccessStatusCode)
				{
					// Sales details added successfully
				}
			}
		}

		public async Task<ActionResult> GetBillData(int BillID)
		{
		//	BillID = 19;
			string apiUrl = $"http://localhost:36942/api/CustomerBill/GetBillDetails?BillID={BillID}";

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
					List<CustomerBillViewModel> BillData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomerBillViewModel>>(data);
					//var sale = salesData.FirstOrDefault(p => p.BillingId == 19);
					// Pass the sales data to the view
					return Json(BillData);
				}

			}
			return View();
		}

		//public async Task<ActionResult> GetBillData(int BillID)
		//{
		//	//var pName=await GetProductDataForCustomerBill();
		//	// Get sales data
		//	var salesData = await GetSalesdataForCustomerBill(BillID);

		//	// Get billing data
		//	var billingData = await GetBillingdataForCustomerBill(BillID);

		//	var viewModelList = new List<CustomerBillViewModel>();

		//	// Map sales data to CustomerBillViewModel
		//	viewModelList.AddRange(salesData.Select(sale => new CustomerBillViewModel
		//	{
		//		SaleDate = sale.SaleDate,
		//		ProductName =Convert.ToString( sale.ProductId),
		//		Quantity = sale.Quantity,
		//		Amount = sale.Amount,
		//	}));

		//	// Map billing data to CustomerBillViewModel
		//	viewModelList.AddRange(billingData.Select(billing => new CustomerBillViewModel
		//	{
		//		BillingId = billing.BillNo,
		//		PaymentType = billing.PaymentType,
		//		//Price=billing.Pr

		//	}));
		//	return View(viewModelList);
		//}
		//public async Task<List<SalesDetails>> GetSalesdataForCustomerBill(int BillingId)
		//{
		//	List<SalesDetails> productDetails = null;
		//	string apiUrl = $"http://localhost:36942/api/Sales/GetFilteredSales?BillId={BillingId}";

		//	using (HttpClient client = new HttpClient())
		//	{
		//		client.BaseAddress = new Uri(apiUrl);
		//		client.DefaultRequestHeaders.Accept.Clear();
		//		client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		//		HttpResponseMessage response = await client.GetAsync(apiUrl);
		//		if (response.IsSuccessStatusCode)
		//		{
		//			var data = await response.Content.ReadAsStringAsync();

		//			 productDetails = JsonConvert.DeserializeObject<List<SalesDetails>>(data);
		//			return productDetails;
		//		}

		//	}
		//	return productDetails;
		//}
		//public async Task<List<BillingInfo>> GetBillingdataForCustomerBill(int BillingId)
		//{
		//	List<BillingInfo> productDetails = null;


		//	string apiUrl = $"http://localhost:36942/api/BillingInfo/GetFilteredBillingInfo?BillId={BillingId}";

		//	using (HttpClient client = new HttpClient())
		//	{
		//		client.BaseAddress = new Uri(apiUrl);
		//		client.DefaultRequestHeaders.Accept.Clear();
		//		client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		//		HttpResponseMessage response = await client.GetAsync(apiUrl);
		//		if (response.IsSuccessStatusCode)
		//		{
		//			var data = await response.Content.ReadAsStringAsync();

		//			 productDetails = JsonConvert.DeserializeObject<List<BillingInfo>>(data);
		//			return productDetails;
		//		}

		//	}
		//	return productDetails;
		//}

		//public async Task<IActionResult> GetProductDataForCustomerBill()
		//{
		//	int productId = 1;
		//	string apiUrl = $"http://localhost:36942/api/Product/GetProductNameWithId?ProductId={productId}";
		//	using (HttpClient client = new HttpClient())
		//	{
		//		client.BaseAddress = new Uri(apiUrl);
		//		client.DefaultRequestHeaders.Accept.Clear();
		//		client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

		//		HttpResponseMessage response = await client.GetAsync(apiUrl);
		//		if (response.IsSuccessStatusCode)
		//		{
		//			var data = await response.Content.ReadAsStringAsync();
		//			var productList = JsonConvert.DeserializeObject<List<Product>>(data);
		//		}

		//	}
		//	return View();
		//}

	}
}
