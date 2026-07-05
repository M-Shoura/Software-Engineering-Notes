using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Products;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product>
    {
        // This constructor will be used for creating an object, That will be used to Get All Products (Criteria = null)
        public ProductWithBrandAndCategorySpecifications() : base()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }

        // This constructor will be used for creating an object, That will be used to Get Product with ID (Criteria = null)
        public ProductWithBrandAndCategorySpecifications(int id) : base(p=>p.Id == id) 
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
