using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;

namespace Talabat.API.Controllers
{
    // [Route("api/[controller]")]    // Written in the BaseApiController , so will not be written here
    // [ApiController]                // Written in the BaseApiController , so will not be written here
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo = productRepo;
        }

        // [HttpGet]   // baseUrl/api/Products
        // public async Task<IActionResult> GetProducts()
        // {
        //     var products = await _productRepo.GetAllAsync();
        // 
        //     // JsonResult result = new JsonResult(products);
        //     // result.StatusCode = 200;
        //     // return result;
        // 
        //     // or
        // 
        //     // OkObjectResult result = new OkObjectResult(products);
        //     // return result;
        // 
        //     // or use helper method
        // 
        //     return Ok(products);
        // }

        [HttpGet]            // baseUrl/api/Products
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            // Last implementation is not the best way ... it's better to return "ActionResult" in API endpoints to specify the result type
            // as here (IEnumerable<Product>)
            var products = await _productRepo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]    // baseUrl/api/Products
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
             var product = await _productRepo.GetAsync(id);
            if (product == null)
                return NotFound();  // status code 404
            
            return Ok(product);     // status code 200
        }
    }
}
