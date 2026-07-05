using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Products;
using Talabat.Core.Specifications.Product_Specs;

namespace Talabat.Core.Services.Contract
{
    public interface IProductService
    {
        Task<Product?> GetProductAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams);
        Task<IReadOnlyList<ProductCategory>> GetCategoriesAsync();
        Task<IReadOnlyList<ProductBrand>> GetBrandsAsync();
        Task<int> GetCountAsync(ProductSpecParams specParams);
    }
}
