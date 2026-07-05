using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public class OrderItem : BaseEntity
    {
        // The EFCore (When making migration) wants a accessable empty parameterless constructor for classes that will be mapped to table 
        // or classes used inside classed mapped to tables so we will make empty constructors for all the classes we've made in order module
        // These Ctors can be private also , to have only by the efcore when generating tables and forcing users to use the other ctors
        public OrderItem()
        {

        }
        public OrderItem(ProductItemOrdered product, decimal price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }


        // defines the product that we selected as an item inside the Order ... 
        // instead of adding the product properties here , put them inside another class (Clean Code)
        public ProductItemOrdered Product { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
