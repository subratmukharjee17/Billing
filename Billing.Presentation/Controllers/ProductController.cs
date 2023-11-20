using Microsoft.AspNetCore.Mvc;

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
    }
}
