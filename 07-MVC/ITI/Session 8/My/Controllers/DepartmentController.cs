using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.RepoServices;

namespace My.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepoService _departmentRepoService;

        public DepartmentController(IDepartmentRepoService departmentRepoService)
        {
            _departmentRepoService = departmentRepoService;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            return View(_departmentRepoService.GetAll());
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View(_departmentRepoService.GetDeptDetails(id));
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
