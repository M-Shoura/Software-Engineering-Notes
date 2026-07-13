using Microsoft.AspNetCore.Mvc;

namespace My.Areas.Teachers.Controllers
{
    public class tchrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
