using Microsoft.EntityFrameworkCore;
using My.Models;

namespace My.RepoServices
{
    public class DepartmentRepoService : IDepartmentRepoService
    {
        private readonly MainDbContext _context;

        public DepartmentRepoService(MainDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetDeptDetails(int id)
        {
            return _context.Departments.FirstOrDefault(x => x.ID == id);
        }

        public void InsertDept(Department d)
        {
            if (d != null)
            {
                _context.Departments.Add(d);
                _context.SaveChanges();
            }
        }

        public void UpdateDept(Department d)
        {
            if (d != null)
            {
                var updateDept = _context.Departments.FirstOrDefault(x => x.ID == d.ID);
                if (updateDept != null)
                {
                    // updatedStd.StdName = s.StdName;
                    // ........
                    // ........
                    // ........
                    // or directly 

                    _context.Departments.Update(d);
                    _context.SaveChanges();
                }
            }
        }

        public void DeleteDept(int id)
        {
            var dept = _context.Departments.FirstOrDefault(x => x.ID == id);
            if (dept != null)
            {
                _context.Remove(dept);
                _context.SaveChanges();
            }
        }
    }
}
