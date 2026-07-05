using Microsoft.AspNetCore.Mvc;

namespace MVC___Session_2.Controllers
{
	public class MoviesController : Controller
	{

		// Action : Public non-static object member method inside the controller
		// baseUrl/Movies/GetMovie/5            
		public string GetMovie(int id)             // this paramters of the action , is called "Model" , will be discussed later in "Model Binding"
		{
			return $"Movie with id = {id}";
		}

		public string Index /*GetAllMovies*/ ()
		{
			return $"All Movies !";
		}

		public IActionResult Test(int id)         // We develop against interfaces
		{
			if (id == 0)
				return new BadRequestResult();

			if (id == 100)
				return new NotFoundResult();


			ContentResult result = new ContentResult();
			result.Content = $"<h1> TEST Id = {id} as a text/html return type</h1>";
			result.StatusCode = 500;               // here we specify the status code for the response
			result.ContentType = "text/html";      // here we specify the returned response type 

			return result;
		}
		public IActionResult Binding(int id, string name, Movie movie)
		{
			return Ok($"id = {id} , name = {name} , movie id = {movie.Id} , movie name = {movie.Name}");
			// URL : https://localhost:7212/Movies/Binding/10/mahmoud
			// return : id = 10 , name = mahmoud , movie id = 10 , movie name = mahmoud

			// URL : https://localhost:7212/Movies/Binding?id=10&name=mahmoud
			// return : id = 10 , name = mahmoud , movie id = 10 , movie name = mahmoud

			// But we didn't give values for the movie object ???
			// to solve this problem we must specify: (ex: movie.name , movie.id , ...)

			// URL : https://localhost:7212/Movies/Binding?id=10&movie.name=mahmoud
			// return : id = 10 , name =  , movie id = 0 , movie name = mahmoud

			// URL : https://localhost:7212/Movies/Binding/100?movie.name=mahmoud
			// return : id = 100 , name =  , movie id = 0 , movie name = mahmoud
		}

		public IActionResult BindingCollection(int id, int[] arr)
		{
			return Ok($"id = {id} , arr[0] = {arr[0]} , arr[1] = {arr[1]}");
			// URL : https://localhost:7212/Movies/BindingCollection/10?arr[0]=100&arr[1]=200
			// return : id = 10 , arr[0] = 100 , arr[1] = 200


		}
		public IActionResult TestRedirect()
		{
			// 1 - Redirect to another website :
			// RedirectResult result = new RedirectResult("https://www.udemy.com/");
			// Note : It's not professional to put the link as we did here , we put links in the "appsettings.json" file
			//        Then how to access the appsettings.json? 
			//        Allowing the dependency injection for services "IConfiguration" , and then asking the CLR to give us an object
			//        from this class in the constructor 
			// 
			// RedirectResult result = new RedirectResult(_configuration["UdemyRedirect"]);    // Takes the key that is in appsettings.json
			// return result ;

			// 2 - Redirect to another endpoint in my web application ?
			// use RedirectToActionResult:
			// RedirectToActionResult result = new RedirectToActionResult("GetMovie","Movies",new { id = 15});
			// return result ;

			// 3 - Redirect to another Route (from the routes we created in the program class , ex: MapControllerRoute ...)
			// RedirectToRouteResult result = new RedirectToRouteResult("default" , new {controller = "Movies" , action = "GetMovie" , id = 11});
			// return result ;


			// we can use Helper methods : 
			// return Redirect("https://www.udemy.com/");
			// return Redirect(_configuration["UdemyRedirect"]);
			// return RedirectToAction("GetMovie" , "Movies" , new {id = 15});
			return RedirectToRoute("default", new { controller = "Movies", action = "GetMovie", id = 11 });
		}

		private readonly IConfiguration _configuration;
		public MoviesController(IConfiguration configuration)
		{
			_configuration = configuration;
		}
	}
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}