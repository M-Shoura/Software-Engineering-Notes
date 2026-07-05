using Microsoft.AspNetCore.Mvc;

namespace MVC___Session_1
{
	public class ProductsController : Controller
	{
		// Action
		// The return type is IActionResult , if we found the product with this id then we will return a "ViewResult" , but if these is no products with
		// this id then we will return a "NotFoundResult" , so we can return many results ... so we will develop against interfaces .
		// The interface called IActionResult is implemented by all the return types of an Action 

		// Note : If the name of the view is the same name of the Action then return View();    (without specifying the name of the view)
		public ViewResult GetProduct(int id)
		{
			return View("ProductDetails");
		}
	}
}
