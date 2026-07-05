using IKIA.PL.ViewModels;
using IKIA.PL.ViewModels.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IKIA.PL.Controllers
{
    // [AllowAnonymous]     --> Default
    [Authorize(AuthenticationSchemes = "Identity.Application")]
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

		// [AllowAnonymous]    
		// We can specify a one action to be "AllowAnonymous" and the entire controller as default is "Authorize"
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
