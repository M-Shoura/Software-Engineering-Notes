using IKIA.BLL.DTOs.Departments;
using IKIA.BLL.Services.Departments;
using IKIA.DAL.Models.Departments;
using IKIA.PL.ViewModels.Departments;
using Microsoft.AspNetCore.Mvc;

namespace IKIA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        #region Services

        // here we will interact with the department service , so we need an object from it (ASK the CLR)

        // // 1 - 
        // [FromServices]
        // public IDepartmentService _departmentService { get; } = null!;

        // 2 - 
        private readonly IDepartmentService _departmentService;

        // for try catch implemented in Create action
        private readonly ILogger<DepartmentController> _logger;

        // for checking the environment we are in try catch implemented in Create action
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(/* [FromServices] default */ IDepartmentService departmentService,
                                                                 ILogger<DepartmentController> logger,
                                                                 IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }

        #endregion

        #region Index

        [HttpGet]  // GET: baseURL/Department/Index
        public IActionResult Index()
        {
            ViewData["Message"] = "Hello from ViewData";
            ViewBag.Message = "Hello from ViewBag";

            // They share the same storage , we will notice that in the view both of them will have the same value "Hello from ViewBag",
            // because it's the last one 


            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        #endregion

        #region Details

        [HttpGet]      // GET :  /Department/Details/id
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        #endregion

        #region Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel DeptVM)
        {
           
            if (!ModelState.IsValid)           
            {                                  
                return View(DeptVM);
            }

            var message = string.Empty;

            try
            {
                var result = _departmentService.CreateDepartment( new CreatedDepartmentDTO(){
                    Code = DeptVM.Code,
                    Name = DeptVM.Name,
                    CreationDate = DeptVM.CreationDate, 
                    Description = DeptVM.Description
                    }
                );

                if (result > 0)
                {
                    TempData["Toast"] = "Department Created Successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Toast"] = "Department Creation Failed";
                    message = "Department is Not Created !!";
                    ModelState.AddModelError(string.Empty, message);
                    return View(DeptVM);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);      


               
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(DeptVM);
                }
                else
                {
                    message = "Department is Not Created";
                    return View("Error", message);
                }
            }

           
        }

        #endregion

        #region Edit

        [HttpGet]   
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
                return NotFound();

            return View(new DepartmentViewModel()
            {
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                Description = department.Description
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, DepartmentViewModel deptVM)
        {
           
            if (!ModelState.IsValid)
                return View(deptVM);

            var message = string.Empty;

            try
            {
                var result = _departmentService.UpdateDepartment(new UpdatedDepartmentDTO()
                {
                    Id = id,
                    Name = deptVM.Name,
                    Code = deptVM.Code,
                    CreationDate = deptVM.CreationDate,
                    Description = deptVM.Description,
                });

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "An error has occured during updating the Department !!";
                }
            }
            catch (Exception ex)
            {
               
                _logger.LogError(ex, ex.Message);

               
                message = _environment.IsDevelopment() ? ex.Message : "An error has occured during updating the Department !!";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(deptVM);

        }

        #endregion

        #region Delete

        [HttpGet]     // GET:      /Department/Delete
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost]     // POST:
        public IActionResult Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var result = _departmentService.DeleteDepartment(id);
                if (result)
                    return RedirectToAction(nameof(Index));

                message = "An error has occured during updating the Department !!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                message = _environment.IsDevelopment() ? ex.Message : "Error when deleting the department";
            }
            ModelState.AddModelError(string.Empty, message);
            return View("Error", message);
        }

        #endregion
    }
}
