using IKIA.DAL.Models.Departments;
using IKIA.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        // This is a field , not a public property -> we want it inside the class only , else we will make it as a property
        private readonly ApplicationDbcontext _dbcontext;       // readonly to avoid any change in it after the initialization 

        public DepartmentRepository(ApplicationDbcontext dbcontext)  // Ask the CLR for object from ApplicationDbContext Implicitly
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Department> GetAll(bool AsNoTracking = true)
        {
            if (AsNoTracking)
                return _dbcontext.Departments.AsNoTracking().ToList();
            
            return _dbcontext.Departments.ToList();
        }

        public IQueryable<Department> GetAllAsIQueryable()
        {
            return _dbcontext.Departments;
            // this will work when using an immediate operator (this is done in the service not here)
        }

        public Department? Get(int id)
        {
            // Notice the Region called "Find EFCore method" first ... 
            var department = _dbcontext.Departments.Find(id);
            return department;
        }

        public int Add(Department entity)
        {
            _dbcontext.Departments.Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int Update(Department entity)
        {
            _dbcontext.Departments.Update(entity);
            return _dbcontext.SaveChanges();
        }

        public int Delete(Department entity)
        {
            _dbcontext.Departments.Remove(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
