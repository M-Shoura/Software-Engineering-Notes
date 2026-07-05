using IKIA.BLL.DTOs.Departments;
using IKIA.BLL.Services.Departments;
using IKIA.DAL.Models.Departments;
using Microsoft.AspNetCore.Mvc;

namespace IKIA.PL.Controllers
{
    public class DepartmentController : Controller
    {
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

        public DepartmentController(/* [FromServices] default */ IDepartmentService departmentService ,
                                                                 ILogger<DepartmentController> logger , 
                                                                 IWebHostEnvironment environment )
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }






        [HttpGet]  // GET: baseURL/Department/Index
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            // Returns an object from class "ViewResult" , it's a helper method (discussed before in session 2)
            // it has 4 overloads discussed before also , we will use the second one that takes a model without a view name
            // because it will go to view named with the same name of the action "Index"
            return View(departments); 
        }





        // For create , we need 2 actions : one for the create view and the other for submiting that create
        // First : for the create view (verb : Get)    baseURL/Department/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // Second : for submiting that create (verb : Post)    baseURL/Department/Create
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDTO DeptDTO)
        {
            // ModelState : the state of all the models (all the parameters of the action .. ) , it's true when the data inside the models
            //              achieved the validations that are inside the classes (ex: validation inside CreatedDepartmentDTO class)
            
            if (!ModelState.IsValid)            // this is server-side validation ... we must use client-side validations also to minimize 
            {                                   // the number of requests that are not valid 
                return View(DeptDTO);
            }

            var message = string.Empty;

            try
            {
                var result = _departmentService.CreateDepartment(DeptDTO);

                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    message = "Department is Not Created !!";
                    ModelState.AddModelError(string.Empty, message);
                    return View(DeptDTO);
                }
            }
            catch (Exception ex)
            {

                // 1 - Log Exception
                //      - using the logging system of the .Net
                //      - using package called "Serial Log" (Recommended and will be discussed later)

                // if we want to use the logging system of .Net , ask the CLR to give an object from ILogger<DepartmentControllder> logger
                // and create and assign field as we usually do ... 

                _logger.LogError(ex,ex.Message);       // this is logged in the console screen 


                // 2 - Set Message 
                // if we in X environment then show message ... else .....

                if(_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(DeptDTO);
                }
                else
                {
                    message = "Department is Not Created";
                    return View("Error" , message);
                }
            }

            // Note : the previous way for handling the exception is not used in most situations ... next sessions we will create a 
            //        middleware to handle all the exceptions in a generic way but and if there is an exception that has a specidic 
            //        handling then we will use the previous mentioned way
        }





        [HttpGet]      // GET :  /Department/Details/id
        public IActionResult Details(int? id)
        {
            if(id == null)
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


    }
}
