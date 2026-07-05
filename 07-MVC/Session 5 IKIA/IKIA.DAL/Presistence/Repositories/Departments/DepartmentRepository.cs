using IKIA.DAL.Models.Departments;
using IKIA.DAL.Presistence.Data;
using IKIA.DAL.Presistence.Repositories._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Repositories.Departments
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        // so we ask the CLR to provide an object from the DbContext here not in the GenericRepository
        public DepartmentRepository(ApplicationDbcontext dbcontext) : base(dbcontext)
        {
        }
    }
}
