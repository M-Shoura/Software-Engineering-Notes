using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Models;

namespace My.Controllers
{
    public class DepartmentController : Controller
    {
        StdDbContext context = new();

        // GET: DepartmentController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController1/Create
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

        // GET: DepartmentController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController1/Edit/5
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

        // GET: DepartmentController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController1/Delete/5
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
