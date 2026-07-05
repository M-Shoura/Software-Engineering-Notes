using Talabat.Core.Entities.Products;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        public ProductWithBrandAndCategorySpecifications(ProductSpecParams specParams) :
            base(p =>
                        (specParams.BrandId == null || p.BrandId == specParams.BrandId)
                        &&
                        (specParams.CategoryId == null || p.CategoryId == specParams.CategoryId)
                        && 
                        (string.IsNullOrEmpty(specParams.search) || p.Name.ToLower().Contains(specParams.search.ToLower()))
            )
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);


            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                // add the sorting 

                switch (specParams.Sort)
                {
                    case "priceAsc":
                        // OrderBy = p => p.Price;
                        // or use the method :
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        // OrderByDesc = p => p.Price;
                        // or use the method :
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                // OrderBy = p => p.Name;
                // or use the method :
                AddOrderBy(p => p.Name);
            }

            ApplyPagination((specParams.PageIndex - 1) * specParams.PageSize, specParams.PageSize);

        }
        public ProductWithBrandAndCategorySpecifications(int id) : base(p => p.Id == id)
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
