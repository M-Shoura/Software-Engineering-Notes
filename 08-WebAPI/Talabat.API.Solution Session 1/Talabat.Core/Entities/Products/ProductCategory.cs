using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Products
{
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }

        // We don't want Navigational Properties here (category has many products , product is for one category)
        // So we need to configure the relationship in fluent APIs , because now the EFCore by convention knows that this is a 
        // ONE TO ONE Relationship which is Wrong , It's ONE TO MANY Relationship

    }
}
