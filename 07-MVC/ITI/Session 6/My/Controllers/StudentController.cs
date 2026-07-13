using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using My.Models;

namespace My.Controllers
{
    public class StudentController : Controller
    {
        StdDbContext context = new();

        // GET: StudentController
        public ActionResult Index()
        {
            return View(context.Students.Include(x=>x.Department).ToList());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.DeptNames = new SelectList(context.Departments.ToList(), "ID", "Name");
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        public ActionResult Create(Student std)
        {
            ViewBag.DeptNames = new SelectList(context.Departments.ToList(), "ID", "Name");
            try
            {
                if(std != null)
                {
                    context.Students.Add(std);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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
