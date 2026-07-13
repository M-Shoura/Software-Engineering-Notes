using IKIA.DAL.Models;
using IKIA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories._Generic
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        Task<IEnumerable<T>> GetAllAsync(bool AsNoTracking = true);
        IQueryable<T> GetAllAsIQueryable();
        Task<T?> GetAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T id);
    }
}
