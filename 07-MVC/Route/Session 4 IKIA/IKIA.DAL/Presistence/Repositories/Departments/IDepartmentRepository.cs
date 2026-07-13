using IKIA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        // we used IEnumerable because we only want to Enumerate on them .. so we didn't use ICollection for example , 
        // also we will not use a specific type , ex: List 
        IEnumerable<Department> GetAll(bool AsNoTracking = true);
        
        // Newly added after knowing the issue in the GetAll Function when making the service .. to solve that problem we can 
        // use the Specification design pattern also (discussed later)
        IQueryable<Department> GetAllAsIQueryable();
        
        Department? Get(int id);

        // they return int because we want them to return the number of rows affected  
        int Add(Department entity);
        int Update(Department entity);
        int Delete(Department entity);

    }
}
