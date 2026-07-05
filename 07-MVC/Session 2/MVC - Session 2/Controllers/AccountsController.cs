using Microsoft.AspNetCore.Mvc;

namespace MVC___Session_2.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
