using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.API.DTOs;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.Product_Specs;
namespace Talabat.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductCategory> _categoryRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IMapper _mapper;

        public ProductsController(
            IGenericRepository<Product> productRepo ,
            IGenericRepository<ProductBrand> brandRepo ,
            IGenericRepository<ProductCategory> categoryRepo ,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            _mapper = mapper;
        }


        [HttpGet]            // baseUrl/api/Products
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetProducts( [FromQuery] ProductSpecParams specParams)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(specParams);
            
            var products = await _productRepo.GetAllWithSpecAsync(specs);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);

            var countSpecs = new ProductWithFilterationForCountSpecifications(specs.Criteria);
            var count = await _productRepo.GetCountAsync(countSpecs);
            
            
            return Ok(new Pagination<ProductToReturnDTO>(specParams.PageIndex, specParams.PageSize,count, data));
        }


         
        [ProducesResponseType(typeof(ProductToReturnDTO),StatusCodes.Status200OK)]      
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]       
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


        [HttpGet("categories")]
        public async Task<ActionResult<IReadOnlyList<ProductCategory>>> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _brandRepo.GetAllAsync();
            return Ok(brands);
        }
    }
}
