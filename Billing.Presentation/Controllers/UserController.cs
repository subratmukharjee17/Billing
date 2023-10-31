using Microsoft.AspNetCore.Mvc;

namespace Billing.Presentation.Controllers
{
    public class UserController : Controller
    {
        public IActionResult AddUser()
        {
            return View("~/Views/Users/AddUser.cshtml");
        }
    }
}
