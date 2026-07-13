using Microsoft.AspNetCore.Mvc;
using My.RepoServices;
using My.ViewModels;

namespace My.Controllers
{
    public class testDataController : Controller
    {
        private readonly IStudentRepoService _studentRepoService;
        private readonly IDepartmentRepoService _departmentRepoService;

        public testDataController(IStudentRepoService studentRepoService, IDepartmentRepoService departmentRepoService)
        {
            _studentRepoService = studentRepoService;
            _departmentRepoService = departmentRepoService;
        }
        public IActionResult ShowStdCrsDetails(int id)
        {
            var std = _studentRepoService.GetStdDetails(id);
            var dept = _departmentRepoService.GetDeptDetails(std.DeptID);
            List<string> CrsNames = new List<string> { "C#", "ASP.NET", "JS" };
            int num = 30;

            // Create an object from the ViewModel : 
            StdDeptCrsLst_ViewModel vm = new() { StdID = std.StudentID, StdName = std.StdName, CourseList = CrsNames, CourseHrs = num, Dept = dept };

            return View(vm);
        }
    }
}
