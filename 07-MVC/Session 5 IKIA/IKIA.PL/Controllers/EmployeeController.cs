using IKIA.BLL.DTOs.Employees;
using IKIA.BLL.Services.Employees;
using IKIA.DAL.Common.Enums;
using IKIA.PL.ViewModels.Employees;
using Microsoft.AspNetCore.Mvc;

namespace IKIA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Services

        private readonly IEmployeeService _employeeService;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger, IWebHostEnvironment environment)
        {
            _employeeService = employeeService;
            _logger = logger;
            _environment = environment;
        }

        #endregion
        
        #region Index

        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeDTO empDTO)
        {
            if (!ModelState.IsValid)
                return View(empDTO);

            var message = string.Empty;
            try
            {
                int result = _employeeService.CreateEmployee(empDTO);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Employee is Not Created !!";
                    ModelState.AddModelError(string.Empty, message);
                    return View(empDTO);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                    message = ex.Message;
                else message = "Employee is Not Created !!";
            }
            ModelState.AddModelError(string.Empty, message);
            return View("Error", message);
        }

        #endregion

        #region Details

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();

            return View(new EmployeeEditViewModel()
            {
                Address = employee.Address,
                Age = employee.Age,
                Email = employee.Email, 
                EmployeeType = EmployeeType.FullTime.ToString(),
                Gender = Gender.Male.ToString(),
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive,
                Name = employee.Name,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary
                
            });
        }

        [HttpPost]
        public ActionResult Edit([FromRoute] int id , EmployeeEditViewModel empVM)
        {
            if (!ModelState.IsValid)
                return View(empVM);

            var message = string.Empty;
            try
            {
                int result = _employeeService.UpdateEmployee(new UpdateEmployeeDTO()
                {
                    Id = id,
                    Salary = empVM.Salary,
                    Address = empVM.Address,
                    Email = empVM.Email,
                    PhoneNumber = empVM.PhoneNumber,
                    Name = empVM.Name,
                    IsActive = empVM.IsActive,
                    HiringDate = empVM.HiringDate,
                    Age = empVM.Age,
                    Gender = (Gender)Enum.Parse(typeof(Gender),empVM.Gender),
                    EmployeeType = (EmployeeType)Enum.Parse(typeof(EmployeeType), empVM.EmployeeType)
                });

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Employee is Not Updated !!";
                    ModelState.AddModelError(string.Empty, message);
                    return View(empVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                    message = ex.Message;
                else message = "Employee is Not Updated !!";
            }
            ModelState.AddModelError(string.Empty, message);
            return View("Error", message);
        }

        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var result = _employeeService.DeleteEmployee(id);

                if (result)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Employee is Not Deleted !!";
                    ModelState.AddModelError(string.Empty, message);
                    return View(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                    message = ex.Message;
                else message = "Employee is Not Deleted !!";
            }
            ModelState.AddModelError(string.Empty, message);
            return View("Error", message);
        }

        #endregion
    }
}
