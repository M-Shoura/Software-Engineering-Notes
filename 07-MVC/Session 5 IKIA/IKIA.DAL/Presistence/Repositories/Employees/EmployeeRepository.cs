using IKIA.DAL.Models.Employees;
using IKIA.DAL.Presistence.Data;
using IKIA.DAL.Presistence.Repositories._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories.Employees
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        // so we ask the CLR to provide an object from the DbContext here not in the GenericRepository
        public EmployeeRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
