using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;

namespace Talabat.Core
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        // OLD Way : (Discussed in Old_UnitOfWork class)
        // // We don't have a specific repository for any type we have .. All of them use the generic repository
        // public IGenericRepository<Product> ProductsRepo { get; set; }
        // public IGenericRepository<ProductBrand> BrandsRepo { get; set; }
        // public IGenericRepository<ProductCategory> CategoriesRepo { get; set; }
        // public IGenericRepository<DeliveryMethod> DeliveryMethodsRepo { get; set; }
        // public IGenericRepository<OrderItem> OrderItemsRepo { get; set; }
        // public IGenericRepository<Order> OrdersRepo { get; set; }


        // Returns a repo for any type T , which is a baseEntity
        IGenericRepository<T> Repository<T>() where T : BaseEntity;

        Task<int> CompleteAsync();
    }
}
