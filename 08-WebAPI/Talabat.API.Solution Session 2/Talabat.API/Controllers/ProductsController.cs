using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.Product_Specs;
namespace Talabat.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo , IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]            // baseUrl/api/Products
        public async Task<ActionResult<IEnumerable<ProductToReturnDTO>>> GetAllProducts()
        {
            var specs = new ProductWithBrandAndCategorySpecifications();
            
            var products = await _productRepo.GetAllWithSpecAsync(specs);
            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDTO>>(products));
        }


         
        [ProducesResponseType(typeof(ProductToReturnDTO),StatusCodes.Status200OK)]      // Not Important , only for improving the Swagger Documentation
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]             // Not Important , only for improving the Swagger Documentation
        [HttpGet("{id}")]    // baseUrl/api/Products
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int id)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(id);
            
            var product = await _productRepo.GetWithSpecAsync(specs);
            if (product == null)
                return NotFound(new ApiResponse(404));
            var productDTO = _mapper.Map<ProductToReturnDTO>(product);  

            return Ok(productDTO);
        }
    }
}
