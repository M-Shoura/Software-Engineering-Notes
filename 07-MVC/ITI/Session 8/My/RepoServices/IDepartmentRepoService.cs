using My.Models;

namespace My.RepoServices
{
    public interface IDepartmentRepoService
    {
        public IEnumerable<Department> GetAll();
        public Department GetDeptDetails(int id);
        public void InsertDept(Department d);
        public void UpdateDept(Department d);
        public void DeleteDept(int id);
    }
}
