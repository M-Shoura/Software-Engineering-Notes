using Microsoft.AspNetCore.Mvc;
using My.Models;
using System.Diagnostics;

namespace My.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Calculate(int x, int y)
        {
            return Content((x+y).ToString());
        }
        public IActionResult Index()
        {
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
    }
}
