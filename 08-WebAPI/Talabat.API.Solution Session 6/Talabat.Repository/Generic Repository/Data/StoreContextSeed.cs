using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Entities.Products;

namespace Talabat.Repository.Generic_Repository.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext dbContext)
        {
            // Now I changed from using [ .Count() = 0 ]   to [ ! .Any() ]  when checking the database tables data 

            if (!dbContext.ProductBrands.Any())
            {
                var BrandsData = File.ReadAllText("../Talabat.Repository/Generic Repository/Data/DataSeeding/brands.json");
                var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);

                if (Brands?.Count() > 0)
                {
                    foreach (var brand in Brands)
                    {
                        dbContext.Set<ProductBrand>().Add(brand);
                    }
                    dbContext.SaveChanges();
                }
            }

            if (!dbContext.ProductCategories.Any())
            {
                var CategoriesData = File.ReadAllText("../Talabat.Repository/Generic Repository/Data/DataSeeding/categories.json");
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(CategoriesData);

                if (Categories?.Count() > 0)
                {
                    foreach (var category in Categories)
                    {
                        dbContext.Set<ProductCategory>().Add(category);
                    }
                    dbContext.SaveChanges();
                } 
            }

            if (!dbContext.Products.Any())
            {
                var ProductsData = File.ReadAllText("../Talabat.Repository/Generic Repository/Data/DataSeeding/products.json");
                var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                if (Products?.Count() > 0)
                {
                    foreach (var product in Products)
                    {
                        dbContext.Set<Product>().Add(product);
                    }
                    dbContext.SaveChanges();
                }
            }

            if (!dbContext.DeliveryMethods.Any())
            {
                var DeliveryData = File.ReadAllText("../Talabat.Repository/Generic Repository/Data/DataSeeding/delivery.json");
                var DeliveryMethodsList = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryData);

                if (DeliveryMethodsList?.Count() > 0)
                {
                    foreach(var delivery in DeliveryMethodsList)
                        dbContext.DeliveryMethods.Add(delivery);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
