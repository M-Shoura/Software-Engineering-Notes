namespace My
{
    public class Regions
    {

        // What is REST (Representational State Transfer)? (search)
        // REST is not mandatory , some applications doesn't support it ... it's an architectural style     

        // anything on the internet is a resource (pictures, videos, ....)

        // Request to a website : http://www.yahoo.com 
        // each URL/End point is a representation to resources state on specific URL/End point.
        // Every URL maps to a function , that each function may have different resources to show on this URL page.
        // No extension shown in URL (ex: .html , ...) this is not shown in modern websites for security

        // All operations on the internet must be a type of CRUD operations : 
        // CRUD : 
        // Create => in Rest called "Post"
        // Read   => in Rest called "Get"
        // Update => in Rest called "Put"
        // Delete => in Rest called "Delete"

        // Note : a function can do more than one CRUD operation 


        // MVC : Model-View-Controller

        // Try to study : SOLID, DRY, Dependency Injection, Builder DP, Repository


        // N-Tier Application: 
        // - Presentation Layer (Frontend)
        // - Business Layer (Business Rules and logic)
        // - Data Access Layer (How we deal with data)

        // Why multi layered apps are better ?
        // - Faster development time
        // - separation of concerns
        // - Not a single point of falure


        // In MVC : 
        // Model : Data Access Layer , resource manager (databases , ... )
        // View  : Presentation Layer , Razor Pages (.cshtml)
        // Controller : Business Layer , Controller class (Methods, Actions)


        // Controller : Class that has the business logic that is provided. Note : Must take care of the naming convention , Must END WITH "Controller" because
        //              the engine uses it. ex: EmployeeController , ... can contain some business logic like ( GetAll() , GetById() , Create() , Delete() , ..)
        //              The controller contains functions that are called "Actions" , the controller directs you to an action. The request starts in the
        //              controller and ends in the controller also ! Note : Not all actions have a view for it AND NOT all actions use the model !


        // Note : not all methods are called actions (non-public methods or static methods => Not actions)


        // Routing : we have MVC routing , and we can use also APIs routing , and same with APIs (discussed later) .. Today we will discuss the default MVC
        //           routing which is called "Dedicated Conventional Routing"

        // Base Address / ControllerName / Endpoint name OR Action name => ex: http://www.MyWebsite/Employee/getAll
        // Note : when writing the URL , it's NOT case-sensitive
        // Note : Anything after the Base Address is called "Root Data" or in APIs called "URI Templete" .. (ex: controller , action , parameter , ... )

        // Controller Tasks : 
        // 1 - Recieve the request
        // 2 - Direct you to the suitable Action / End Point
        // 3 - Interact with Model Layer "ex: Database" (If needed)
        // 4 - Decide Result is displayed in which view
        // 5 - Send response to Client


        // Request steps : 
        // 1 - Go to the right controller 
        // 2 - Go to the Model "ex: Database" if needed
        // 3 - Return back to the Controller with wanted Data
        // 4 - Go to a specific View (Razor page)

        // Note : some controllers doesn't need models or views (models and views are optional)


        // Application start point : Program.cs -> Main function , it contains settings that specify how the application will run (ex: Routing of the app)
        //                                                         so we now Generate the routing table of the application (Available URLs / End points).

        // ------------------------------------------------------------------------------------------------------------------------------------------------


        // Starting with VS : make a new project , ASP.NET MVC Core , can be also ASP.NET Empty Project and we make the folder structures and install packages 
        //                    but it's better to use the templete


        // All configurations will be in JSON Files : 
        // - appsettings.json
        // - appsettings.Development.json
        // - launchSettings.json


        // Note : In MVC , all controllers we will use MUST inherit from "Controller" that has MVC specific functions and properties (ex: ViewBag , ViewData , .),
        //        and this Controller class inherits from "ControllerBase" , this ControllerBase class has object "RouteData" (things after the Base Address) ,
        //        object for "Request" , object for "Response" , ..... 


        // We will notice that we have a folder called "Views" , that has folder for each controller , so when making a view it must be inside the 
        // right folder ! Also we will have a folder called "Shared" (will contain the shared views between all controllers , ex: _Layout) and two .cshtml 
        // files (_ViewImports and _ViewStarts) , the _ViewStarts is the same as "_PageStart" that we discussed before (we put in it the properties that we 
        // want to be applied in ALL VIEWS) .. _ViewImports will be discussed later.

        // Note : any .cshtml file that starts with _ is "Non-browsable" and "does a special thing"


        // wwwroot folder : special folder that has a special name that is used by the application to read static files
        //                  Static files : (ex: images (.jpg  .gif  ...)  , music files  ,  fonts  ,  .html  ,  .css  ,  .js  ,  bootstrap/JQuesry files , ... )
        //                  we can read these static files from other places but it's not recommended



        // ------------------------------------------------------------------------------------------------------------------------------------------------


        // Routing : 
        // in the main function : 
        // app.UseRouting();                   // Enable Routing and Generate the Routing Table (implicitly)


        // where is the templetes of valid URLs ?


        // - This is a valid URL (It's the default templete): 
        //      app.MapControllerRoute(
        //         name: "default",
        //         pattern: "{controller=Home}/{action=Index}/{id?}");

        // Note : names must be unique , because we put them inside the Routing table
        // Routing table : Name  -  Pattern  -  Defaults

        // anything between curly brackets must be given as input ... 
        // ex: {controller=Home} => we must give a controller , and if not given then the default is "Home". the controller here is the thing after the 
        //                          base URL , so we must find this in the controls of the application.
        // ex: {id?} => the id can be given or no , it's Optional 

        // So when we have a request , the request must match any of the valid patterns , and we can have more than one valid pattern ...
        // Add a new pattern : 
        //      app.MapControllerRoute(
        //         name: "otherRoute",
        //         pattern: "testtt"
        //         defaults: new { controller = "test" , action = "testAction"});

        // ex: http://www.myWebsite/testRoute/testAction                // NOT Valid (where is "testtt" in the URL ?????)
        // ex: http://www.myWebsite/testtt/test/testAction              // Valid (must have controller "test" that has action "testAction")
        // ex: http://www.myWebsite/testtt/testR/testA                  // Valid if we have a controller called "testR" and an action inside it called "testA"


        // Adding a new Pattern : 
        //      app.MapControllerRoute(
        //         name: "myRoute",
        //         pattern: "MVC/SD/{*a}"             // the URL must contain MVC/SD/AnyCharactersHere
        //         defaults: new { controller = "Employee" , action = "Get"});


        // Note : Take care of the Routes ordering , as the request is passed on the routes with the order of writing ! so the MOST GENERAL ROUTE MUST BE in 
        //        the END. Most General Route : the route doesn't have a static part.

        // Note : the name of the Route or pattern DOESN'T INDECATE ANYTHING , so the first is called "default" but this is only it's name


        // -----------------------------------------------------------------------------------------------------------------------------------------------


        // Actions (Functions inside the controller) :  

        // This is a valid Action , why ? 
        // it's a function that is public and non-static ! 
        //   public string testAction()
        //   {
        //       return "Hello Test Action .....................";
        //   }


        // Things that can be returned from an Action :
        // - Content : String or anything that can be converted to string (.ToString())
        // - View : HTML with C# (Razor Page) 
        // - JSON
        // - void
        // - File 
        // - Not Found 
        // ..... 
        // ..... 


        // so to make auto-generation easier and to put some rules , we now have some return types 

        // - ContentResult 
        // - JsonResult
        // - ViewResult
        // .............
        // .............

        //   public ContentResult testAction()
        //   {
        //       // 1. Declare Object from ContentResult; 
        //       // 2. Set Data 
        //       // 3. Return the Object
        //
        //       ContentResult res = new();
        //       res.Content = "Hello Test Action .....................";
        //       return res;
        //   }

        // What if we will return ContentResult in a case , and return JsonResult in another case ? so now the return type of the function must be 
        // their parent ! 
        // Parent Class => ActionResult : abstract class that implements IActionResult : Interface 

        // So the return type of the function(action) can be any of them (ActionResult or IActionResult) and inside the function(action) we can return anything inherit from them
        // ex: ContentResult , ViewResult , ... 


        //   public IActionResult testAction()
        //   {
        //       if(....)
        //       {
        //          ContentResult res = new();
        //          res.Content = "Hello Test Action .....................";
        //          return res;
        //       }
        //       else
        //       {
        //          JsonResult jRes = new(new{Id = 1, Name = "Shoura"});
        //          return jRes;
        //       }
        //   }


        // Last Version : instead of making an object , then setting it's data , then returning it .. we can make this in only one line using the function
        //                of each type of what we can return from Action methods , ContentResult => use function "Content()" , ViewResult => use function "View()"
        // return Content("Content or string ... ");
        // return View("ViewName");


        //   public IActionResult testAction()
        //   {
        //       if(....)
        //       {
        //          return Content("Hello Test Action .....................");
        //       }
        //       else
        //       {
        //          return Json(new{Id = 1, Name = "Shoura"});
        //       }
        //   }


        // Note : with Views only , if we are returning "View()" inside an action , without specifying a name for it , then it will by default take 
        //        the name of the action and we will try to find a view with this name inside the folder of the Controller or in the Shared folder !
        //        This is the recommended , the view must have a name = name of the action 

        //   public IActionResult testAction()
        //   {
        //       return View();                        // return the view with the same name of the action "testAction" , if not found then ERROR at runtime
        //   }

        // Note : VS shortcut , we can go inside the action => right click => add view , this will add a view inside the right folder with and having same 
        //        name of the Action 


        // -------------------------------------------------------------------------------------------------------------------------------------------------


        // How to send data from an Action inside a controller to a view to be used inside it ? 
        // we have 3 ways : 
        // 1 - ViewData 
        // 2 - ViewBag   (Discussed next session)
        // 3 - TempData  (Discussed next session)


        // ViewData : 
        // The controller inherits from class called "Controller" , this class has a "ViewDataDictionary" , which is a dictionary (key,value pair) .. the 
        // key is a string and the value can be anything (object) 

        // ex1:
        // inside an Action inside a controller : 
        //    ViewData["AnyKey"] = "String of ViewData";
        // inside the view : 
        //    <div> Data from controller :   @ViewData["AnyKey"]; </div> 


        // ex2: 
        // inside an Action inside a controller : 
        //    ViewData["BooksList"] = new List<string>(){"C#", "DesignPatterns"};
        // inside the view : 
        // <ol>
        //    @foreach(var book in (List<string>) ViewData["BooksList"])         // Must be casted , because the value of the ViewDataDictionary is "object"
        //    {
        //        <li> @item </li>
        //    }
        // </ol>

    }
}