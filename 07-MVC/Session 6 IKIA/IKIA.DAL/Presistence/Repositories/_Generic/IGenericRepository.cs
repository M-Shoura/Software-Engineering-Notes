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
        IEnumerable<T> GetAll(bool AsNoTracking = true);
        IQueryable<T> GetAllAsIQueryable();
        T? Get(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T id);
    }
}
