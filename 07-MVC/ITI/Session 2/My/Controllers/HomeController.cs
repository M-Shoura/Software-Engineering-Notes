using Microsoft.AspNetCore.Mvc;

namespace My.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
