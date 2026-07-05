using IKIA.DAL.Models.Employees;
using IKIA.DAL.Presistence.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories.Employees
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        // We write here any function signature that is specified to Employee Entity (not shares between entities that
        // implement "IGenericRepository")
    }
}
