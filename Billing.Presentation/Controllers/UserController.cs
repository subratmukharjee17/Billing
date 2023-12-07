using Billing.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;


namespace Billing.Presentation.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:36942/api");
        private readonly HttpClient _httpClient;
        public UserController() 
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        //public IActionResult AddUser()
        //{
        //    return View("~/Views/Users/AddUser.cshtml");
        //}

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User userInfo)
        {
            string data = JsonConvert.SerializeObject(userInfo);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/User/AddUser", content);
            if (response.IsSuccessStatusCode)
            {
                var successMessage = new { message = "User created" };
                return Json(successMessage);
            }
            else
            {
                var errorMessage = new { error = "Invalid Input" };
                return Json(errorMessage);
            }
        }

    }
}
