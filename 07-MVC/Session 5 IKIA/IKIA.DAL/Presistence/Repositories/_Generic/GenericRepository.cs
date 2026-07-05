using IKIA.DAL.Models;
using IKIA.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace IKIA.DAL.Presistence.Repositories._Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ModelBase
    {
        private protected readonly ApplicationDbcontext _dbcontext;
        public GenericRepository(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<T> GetAll(bool AsNoTracking = true)
        {
            if (AsNoTracking)
                return _dbcontext.Set<T>().Where(x=>!x.IsDeleted).AsNoTracking().ToList();

            return _dbcontext.Set<T>().Where(x => !x.IsDeleted).ToList();
        }

        public IQueryable<T> GetAllAsIQueryable()
        {
            return _dbcontext.Set<T>().Where(x=>!x.IsDeleted);
        }

        public T? Get(int id)
        {

            var result = _dbcontext.Set<T>().Find(id);
            if (result is null || result.IsDeleted)
                return null;
            
            return result;
        }

        public int Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbcontext.Set<T>().Update(entity);
            return _dbcontext.SaveChanges();
        }

        public int Delete(T entity)
        {
            entity.IsDeleted = true;
            _dbcontext.Set<T>().Update(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
