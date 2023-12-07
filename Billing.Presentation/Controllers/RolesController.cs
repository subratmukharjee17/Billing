using Microsoft.AspNetCore.Mvc;

namespace Billing.Presentation.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult Roles()
        {
            return View("~/Views/Users/Roles.cshtml");
        }
    }
}
