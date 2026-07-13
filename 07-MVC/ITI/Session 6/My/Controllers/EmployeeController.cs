using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Models;

namespace My.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(EmployeeList.Employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View(EmployeeList.Employees.Where(x=>x.ID == id).FirstOrDefault());
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if(string.IsNullOrEmpty(emp.Name))
            {
                ModelState.AddModelError("Name", "Name must be added !!!!!! ");
            }
            if(emp.Age<18)
            {
                ModelState.AddModelError("Age", "Age must be >= 18 !!!!!!");
            }
            if(ModelState.IsValid)
            {
                EmployeeList.Employees.Add(emp);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
