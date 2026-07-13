using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Models;
using My.RepoServices;

namespace My.Controllers
{
    public class StudentController : Controller
    {

        // StudentRepoService studentRepoService = new();           // don't do this , as this is composition and Tightly coupled !
        //                                                          // but request service of type "IStudentRepoService" and inject that object in the ctor of the 
        //                                                          // controller , and we must add this type inside the DI Container

        private readonly IStudentRepoService _studentRepoService;
        private readonly IDepartmentRepoService _departmentRepoService;

        public StudentController(IStudentRepoService studentService, IDepartmentRepoService departmentRepoService)
        {
            _studentRepoService = studentService;
            _departmentRepoService = departmentRepoService;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            return View(_studentRepoService.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_studentRepoService.GetStdDetails(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.DeptList = _departmentRepoService.GetAll();
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        public ActionResult Create(Student s)
        {
            ViewBag.DeptList = _departmentRepoService.GetAll();
            if (ModelState.IsValid)
            {
                try
                {
                    _studentRepoService.InsertStd(s);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.DeptList = _departmentRepoService.GetAll();
            return View(_studentRepoService.GetStdDetails(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            ViewBag.DeptList = _departmentRepoService.GetAll();
            if (ModelState.IsValid)
            {
                try
                {
                    _studentRepoService.UpdateStd(s);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(s);
                }
            }
            else
                return View(s);
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_studentRepoService.GetStdDetails(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studentRepoService.DeleteStd(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
                return View();
        }
    }
}
