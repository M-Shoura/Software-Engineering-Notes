using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public class ProductItemOrdered
    {
        // The EFCore (When making migration) wants a accessable empty parameterless constructor for classes that will be mapped to table 
        // or classes used inside classed mapped to tables so we will make empty constructors for all the classes we've made in order module
        // These Ctors can be private also , to have only by the efcore when generating tables and forcing users to use the other ctors
        public ProductItemOrdered()
        {

        }
        public ProductItemOrdered(int productId, string productName, string pictureUrl)
        {
            ProductId = productId;
            ProductName = productName;
            PictureURL = pictureUrl;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureURL { get; set; }
    }
}
