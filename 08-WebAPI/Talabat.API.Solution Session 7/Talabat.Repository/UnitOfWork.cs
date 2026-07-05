using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository.Generic_Repository;
using Talabat.Repository.Generic_Repository.Data;

namespace Talabat.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;

        // private Dictionary<string, GenericRepository<BaseEntity>> repositories; 
        // We could use the Hash Table also , to avoid many lines of casting .. but it's not recommended to use non-generic collection incase
        // boxing and unboxing will happen frequently (this will not happen in our case because the key and value are reference types)
        private Hashtable repositories;


        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            repositories = new Hashtable();
        }
        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;
            if(!repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_dbContext);
                repositories.Add(key, repository);
            }
            return repositories[key] as IGenericRepository<T>;
        }
        

        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();
        

        public async ValueTask DisposeAsync()
            => await _dbContext.DisposeAsync();

    }
}
