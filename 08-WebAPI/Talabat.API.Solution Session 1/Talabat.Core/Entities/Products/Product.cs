using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }


        // [ForeignKey(nameof(Brand))]                     // Done by Fluent APIs 
        public int BrandId { get; set; }                   // Foreign Key Column
        public ProductBrand Brand { get; set; }            // Navigational Property [One]



        // [ForeignKey(nameof(Category))]                  // Done by Fluent APIs 
        public int CategoryId { get; set; }                // Foreign Key Column
        public ProductCategory Category { get; set; }      // Navigational Property [One]


    }
}
