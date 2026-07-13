using Microsoft.AspNetCore.Mvc;
using MySol.Models;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace MySol.Controllers
{
    public class CarController : Controller
    {
        public IActionResult GetAllCars()
        {
            return View(CarList.Cars);
        }
        public IActionResult SelectCarById(int id)
        {
            var car = CarList.Cars.FirstOrDefault(x => x.Num == id);
            if (car != null)
            {
                return View(car);
            }
            return NotFound();
        }
        public IActionResult DeleteCar(int id)
        {
            var carToBeDeleted = CarList.Cars.FirstOrDefault(x => x.Num == id);
            if (carToBeDeleted != null)
                CarList.Cars.Remove(carToBeDeleted);
            return RedirectToAction("GetAllCars");
        }

        public IActionResult CreateNewCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewCar(int id, string manfacture, string model, string color)
        {
            CarList.Cars.Add(new Car() { Num = id, Manfacture = manfacture, Model = model, Color = color });
            return RedirectToAction("GetAllCars");
        }
        public IActionResult UpdateCar(int id)
        {
            var car = CarList.Cars.FirstOrDefault(x => x.Num == id);
            if (car != null)
            {
                return View(car);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult UpdateCar(int id, string manfacture, string model, string color)
        {
            var carToBeUpdated = CarList.Cars.FirstOrDefault(x => x.Num == id);
            if (carToBeUpdated != null)
            {
                carToBeUpdated.Model = model;
                carToBeUpdated.Color = color;
                carToBeUpdated.Manfacture = manfacture;
            }
            return RedirectToAction("GetAllCars");
        }
    }
}
