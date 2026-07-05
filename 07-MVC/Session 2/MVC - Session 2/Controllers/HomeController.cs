using Microsoft.AspNetCore.Mvc;

namespace MVC___Session_2.Controllers
{
	public class HomeController : Controller
	{
        [HttpGet]       // baseURL/Home/Index
		public IActionResult Index()
		{
			// Note : We are now using the helper method for ViewResult , old way ViewResult result = new ViewResult(); return result;
			// if we didn't specify the name of the view then it will search for a view named with the action name

			// We have 4 overloads : 
			// 1 - return View();                              // sending nothing and will search for a view named with the action name 
			// 2 - return View(new Movie());                   // sending a model to be viewed
			// 3 - return View("ViewName");                    // sending a view name without any models
			// 4 - return View("ViewName" , new Movie());      // sending a view name and also a model 

			return View();
		}

        [HttpGet]       // baseURL/Home/AboutUs
        public IActionResult AboutUs()
        {
            
            return View();
        }


        [HttpGet]       // baseURL/Home/ContactUs
        public IActionResult ContactUs()
        {
           
            return View();
        }

        [HttpGet]       // baseURL/Home/Privacy
        public IActionResult Privacy()
        {
           
            return View();
        }
    }
}
