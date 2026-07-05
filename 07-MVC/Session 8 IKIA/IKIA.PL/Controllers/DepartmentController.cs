using AutoMapper;
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

        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService,
                                    ILogger<DepartmentController> logger,
                                    IWebHostEnvironment environment,
                                    IMapper mapper)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
            _mapper = mapper;
        }

        #endregion

        #region Index

        [HttpGet]  // GET: baseURL/Department/Index
        public async Task<IActionResult> Index()
        {
            ViewData["Message"] = "Hello from ViewData";
            ViewBag.Message = "Hello from ViewBag";

            // They share the same storage , we will notice that in the view both of them will have the same value "Hello from ViewBag",
            // because it's the last one 


            var departments = await _departmentService.GetAllDepartmentsAsync();
            return View(departments);
        }

        #endregion

        #region Details

        [HttpGet]      // GET :  /Department/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var department = await _departmentService.GetDepartmentByIdAsync(id.Value);
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
        public async Task<IActionResult> Create(DepartmentViewModel DeptVM)
        {
           
            if (!ModelState.IsValid)           
            {                                  
                return View(DeptVM);
            }

            var message = string.Empty;

            try
            {
                // Using AutoMapper

                // var dto = _mapper.Map<DepartmentViewModel,CreatedDepartmentDTO>(DeptVM);
                // or without specifying the TSource , TDestination only with the source object that we map to destination
                var dto = _mapper.Map<CreatedDepartmentDTO>(DeptVM);

                var result = await _departmentService.CreateDepartmentAsync(dto);
                
                // // Manual mapping
                // var result = _departmentService.CreateDepartment( new CreatedDepartmentDTO(){
                //     Code = DeptVM.Code,
                //     Name = DeptVM.Name,
                //     CreationDate = DeptVM.CreationDate, 
                //     Description = DeptVM.Description
                //     }
                // );

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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var department = await _departmentService.GetDepartmentByIdAsync(id.Value);
            if (department == null)
                return NotFound();


            // var result = _mapper.Map<DepartmentDetailsToReturnDTO, DepartmentViewModel>(department);
            // or without specifying the TSource , TDestination only with the source object that we map to destination
            var result = _mapper.Map<DepartmentViewModel>(department);


            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, DepartmentViewModel deptVM)
        {
           
            if (!ModelState.IsValid)
                return View(deptVM);

            var message = string.Empty;

            try
            {
                // var dto = _mapper.Map<DepartmentViewModel,UpdatedDepartmentDTO>(deptVM);
                // or without specifying the TSource , TDestination only with the source object that we map to destination
                var dto = _mapper.Map<UpdatedDepartmentDTO>(deptVM);


                var result = await _departmentService.UpdateDepartmentAsync(dto);

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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();
            var department = await _departmentService.GetDepartmentByIdAsync(id.Value);
            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost]     // POST:
        public async Task<IActionResult> Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var result = await _departmentService.DeleteDepartmentAsync(id);
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
