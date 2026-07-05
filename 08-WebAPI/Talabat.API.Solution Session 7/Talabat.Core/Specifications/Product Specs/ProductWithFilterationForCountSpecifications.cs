using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Products;

namespace Talabat.Core.Specifications.Product_Specs
{
    public class ProductWithFilterationForCountSpecifications : BaseSpecifications<Product>
    {
        public ProductWithFilterationForCountSpecifications(Expression<Func<Product,bool>> criteria):base(criteria)
        {
            
        }
    }
}
