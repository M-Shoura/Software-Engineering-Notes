using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository.Generic_Repository;
using Talabat.Repository.Generic_Repository.Data;

namespace Talabat.Repository
{
    public class Old_UnitOfWork // : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;


        public IGenericRepository<Product> ProductsRepo { get; set; }
        public IGenericRepository<ProductBrand> BrandsRepo { get; set; }
        public IGenericRepository<ProductCategory> CategoriesRepo { get; set; }
        public IGenericRepository<DeliveryMethod> DeliveryMethodsRepo { get; set; }
        public IGenericRepository<OrderItem> OrderItemsRepo { get; set; }
        public IGenericRepository<Order> OrdersRepo { get; set; }


        public Old_UnitOfWork(StoreDbContext dbContext)  // ask the CLR to provide an object from storeDbContext , to be able to implement
                                                     // "Complete" and "Dispose" functions
        {
            _dbContext = dbContext;
            
            // we must initialize every Repo with a new object , to avoid getting Null when using the property
            ProductsRepo = new GenericRepository<Product>(_dbContext);
            BrandsRepo = new GenericRepository<ProductBrand>(_dbContext);
            CategoriesRepo = new GenericRepository<ProductCategory>(_dbContext);
            DeliveryMethodsRepo = new GenericRepository<DeliveryMethod>(_dbContext);
            OrderItemsRepo = new GenericRepository<OrderItem>(_dbContext);
            OrdersRepo = new GenericRepository<Order>(_dbContext);

            // The previous implementation is bad ! 
            // imagine wanting only one repo , we will initialize all the other repos that i will not use 
            // So I will not create a new object until it is Requested (it's not a must to create a new repository , we will store repos
            // that we've created in a Dictionary and then return it if exists , if not exists then create a new one)


            // Imagine also adding a new repository , we must add it inside the interface , then make a property for it here , then initialize
            // it .. this is bad (Doesn't follow SOLID "O") , So we will use a Dictionary inside the Interface

            // The new Implementation is in class "UnitOfWork"
        }
        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
