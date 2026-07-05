using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities.Products;
using Talabat.Core.Services.Contract;
using Talabat.Core.Specifications.Product_Specs;

namespace Talabat.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product?> GetProductAsync(int id)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(id);
            return await _unitOfWork.Repository<Product>().GetWithSpecAsync(specs);
        }
        public async Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams)
        {
            var specs = new ProductWithBrandAndCategorySpecifications(specParams);
            return await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(specs);
        }
        public async Task<int> GetCountAsync(ProductSpecParams specParams)
        {
            var specs = new ProductWithFilterationForCountSpecifications(new ProductWithBrandAndCategorySpecifications(specParams).Criteria);
            return await _unitOfWork.Repository<Product>().GetCountAsync(specs);
        }
        public async Task<IReadOnlyList<ProductCategory>> GetCategoriesAsync()
        {
            return await _unitOfWork.Repository<ProductCategory>().GetAllAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetBrandsAsync()
        {
            return await _unitOfWork.Repository<ProductBrand>().GetAllAsync();
        }

    }
}
