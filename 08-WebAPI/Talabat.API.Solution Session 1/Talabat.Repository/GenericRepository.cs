using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // Till now we need only "GetAll" and "GetById" .... because "create/update/delete" will be inside the MVC controller of the admin
        // dashboard ...

        private readonly StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // This problem will be solved next session by using the Specification Design pattern (can use Lazy loading also)
            if (typeof(T) == typeof(Product))
                return (IEnumerable<T>) await _dbContext.Set<Product>().Include(p=>p.Brand).Include(p=>p.Category).ToListAsync();
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            // This problem will be solved next session by using the Specification Design pattern (can use Lazy loading also)
            if (typeof(T) == typeof(Product))
            {
                var product = await _dbContext.Set<Product>().Where(p => p.Id == id).Include(p => p.Brand).Include(p => p.Category).FirstOrDefaultAsync();
            }

            return await _dbContext.Set<T>().FindAsync(id);
        }
    }
}
