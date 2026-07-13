using Microsoft.AspNetCore.Mvc;

namespace My.Areas.Students.Controllers
{
    public class stdController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
