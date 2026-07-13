using IKIA.DAL.Models.Departments;
using IKIA.DAL.Models.Employees;
using IKIA.DAL.Presistence.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories.Departments
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        // We write here any function signature that is specified to Department Entity (not shares between entities that
        // implement "IGenericRepository")
    }
}
