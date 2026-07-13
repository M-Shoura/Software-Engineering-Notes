namespace Regions
{
    internal class Region
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // AddController vs AddMvc vs AddControllersWithViews vs AddRazorPages :
            //                          https://dotnettutorials.net/lesson/difference-between-addmvc-and-addmvccore-method/

            // What is DOM manipulation ?
            // What is nameof and why it's important to avoid errors ?
            // more about model binfing from services 
            // Bootstrap : https://getbootstrap.com/docs/5.0/getting-started/introduction/
            // What is cdnjs ?
            // Sections and render section in Views
            // What is an area in C# application (same as schema in database)?

            /* End ******************************************************************************************************************/

            #endregion


            #region Revision

            /* Start *****************************************************************************************************************/

            // ASP.NET Core is the Framework in .NET Platform that we can use to make web applications and web APIs , Web applications through
            // two projects : ASP.NET core MVC (Architecture pattern : MVC) and ASP.NET Razor pages (Architecture pattern : MVVM) .. MVC is better 
            // because the "Separation of Concerns" ... The project is seperated into 3 main components : Model , view and controller 

            // Controller : Process the request of the client ... Class has name that ends with "Controller" keyword and inherits from class "Controller"
            //              (In case it's an API controller then the controller must inherit from class "ControllerBase"). Inside the controller class 
            //              we have some methods or functions called "Actions" in MVC , or "Endpoints" in APIs. inside the controller we have almost 
            //              eight Actions : GetAll , GetById , 2 create , 2 update , 2 delete as we discussed last session

            // Model : class that represents the shape of the data that is in the database table , ex: product model , ... 

            // View : HTML Page having dynamic content by writing C# Code in it (Razor page .cshtml) 



            // Any ASP.NET Core application is actually 2 projects : Application code (MVC , Razor pages , API or all of them) and a console application
            // called Kestrel. in .NET 5 and bafore , the kestrel was written as two classes : Program and Startup .. but starting from .Net 6 it's written
            // only in one file "Program" class


            // The main function is the Entry point , inside the main function we call "CreateHostBuilder" function that is in the same class "Program"
            // this function creates the Kestrel for us and configure it using the "Startup" class , the Kestrel is configured in the "Startup" class by
            // the two functions : "ConfigureServices" and "Configure" then we build and run the return of function "CreateHostBuilder" (the first function
            // we called in the main) , then we can process any requests ! The two functions "ConfigureServices" and "Configure" are called by the runtime
            // (CLR) .

            // "ConfigureServices" function : Register the services (built-in or custom services) ex: DbContext service is a custom service we can register 
            //                                it in this function , to allow the CLR to give us an object from DbContext when we want (Will be discussed)
            // "Configure" function : create the pipeline/middlewares that the request will go through when the request is in the kestrel , ex : we use 
            //                        middleware "UseRouting" to know the URL written by the client matches which route . Also "UseEndPoints" function
            //                        to define the Routes we have in the web application 

            // app.UseEndpoints(endpoints =>                          
            // 	{
            // 		endpoints.MapGet("/", async context =>
            // 		{
            //          // context.Request                            context => has base type "HttpContext" that has Request or Response 
            // 			await context.Response.WriteAsync("Hello World!");
            //      });
            //
            // 		endpoints.MapGet("/Shoura", async context =>   // The verb can be MapPost , means that it's a Post Method and cannot be executed by browser  
            // 		{
            // 			await context.Response.WriteAsync("Hello Shoura!");
            // 		});
            // 	});

            /* End ******************************************************************************************************************/

            #endregion


            #region Routing

            /* Start *****************************************************************************************************************/

            // The first middleware that is responsible for routing : "UseRouting()" middleware , the URL the client entered matches which Route in 
            // our program using the Routing Table . To add routes in this table we use methods like "MapGet" [Get verb] , "MapPost" [Post verb] , 
            // "MapPut" [Put verb] , "MapDelete" [Delete verb]

            // Through the Browser , if we have two Routes with the same Segments and with the same verb (verb that can be used with browsers is "Get" verb)
            // then we will have an exception "AmbiguousMatchException: The request matched multiple endpoints"

            // Through Postman , if we have two Routes with the same Segments and with the same verb (any verb of the four verbs) then we will have an
            // exception "AmbiguousMatchException: The request matched multiple endpoints"

            // so it's important to have routes with unique {segment, verb}


            // Example of Segments : /Shoura/Movies?id=5              -> Shoura is a segment , Movies is a segment
            // Example of querey parameter : /Shoura/Movies?id=5      -> id=5 is a query parameter

            // segments can be one of three types : 
            // 1 - Static segment :     /Shoura                                  => Must be written as this /Shoura
            // 2 - Variable segment :   /{id}   or   /{id:int}   or   /{id?}     => first must have an id without specifying the type , second must have an id 
            //                                                                      with type int , last means that we can provide id or not (optional)
            // 3 - Mixed segment :      /XX{id}                                  => Must provide id but , ex: /XX10 or /XXten as we didn't specify a type



            // Default route (called aso minimal APIs) :
            // Note : not used and not recommended because if we want to use it then we must write a route for each action in each controller we have
            //
            // app.MapGet("/Shoura", async context =>
            // 	{
            // 		// context.Response.StatusCode = 501;
            // 		await context.Response.WriteAsync("Hello Shoura");
            //  });


            // Routing with a generic way (most used and recommended) : used to handle routing for controllers (MVC or API) in a generic way
            // we don't specify a verb, ex: get , post , put , delete
            // app.MapControllerRoute(
            // 		name: "default",
            // 		pattern: "{controller}/{action}/{id?}"     // Base URL / controller name / then action name / then id that is not mandatory 
            // 	);
            // 
            // The method "MapControllerRoute" uses 5 parameters: 2 mandatory (name and pattern [URL Path]) , and 3 optional (defaults, constraints, data tokens)
            // Any variable Segment can be named as we want , but "controller" and "action" variable segments must be named like this


            // The action is an object member method in the controller class , so to execute this action we must have an object from the controller class
            // This is done by the CLR so we must allow the dependency injection for this service and all the other services , ex: 
            // - Allow dependency injection for services that perform "Controller Activation" [making objects from controller class]
            // - Allow dependency injection for services that perform "Model Binding"         [Will be discussed later]
            // - Allow dependency injection for services that perform "Action Filters"        [Will be discussed later]

            // so we must know all the services wanted and register them in the dependency injection collection , or use a function that registers 
            // the services we want for a specific purpose ! 
            // Functions : 
            // 1 - builder.Services.AddControllers();            -> Registers Required services for a [ API ] project
            // 2 - builder.Services.AddControllersWithViews();   -> Registers Required services for a [ API / MVC ] project
            // 3 - builder.Services.AddRazorPages();             -> Registers Required services for a [ Razor Pages ] project
            // 4 - builder.Services.AddMvc();                    -> Registers Required services for all projects [API / MVC / Razor Pages]

            // if we didn't add the required services using one of the previous mentioned functions then we will have an error while trying to run the
            // application OR an exception while the program runs [ex: we write a URL that returns a view but we registered only services for API
            //                                                         project .AddControllers()] : "Unable to find the required services"

            /* End ******************************************************************************************************************/

            #endregion


            #region First Controller

            /* Start *****************************************************************************************************************/

            // The MVC Controller :
            // 1 - named as "XController" , ex: MoviesController
            // 2 - inherits from class "Controller"

            // The Action : public non-static object member method inside controller

            // URL = URL Base + URL Path 
            // URL Path (Route Data) : consists of Segments , segments can be static /Hamada , variable /{action} or mixed /XX{action} 
            // We have 2 segments that must be variables and having the same names (contoller and action)


            // The parameter of the action is called "Model" , can take it's values from 6 places will be discussed in the "Model Binding region ..."
            // Note : we have Priorities in Model binding , and also we can force the action to bind it's model valued from one of the 6 places using
            // data annotation , Ex: public void GetMovie( [FromHeader] int id) { }

            // Note : Take care about the naming of the model name and the name that we wrote inside the controller route , ex
            // app.MapControllerRoute(
            // 		name: "default",
            // 		pattern /*URL Path*/: "{controller}/{action}/{id?}"
            // 	);
            // Here it's called id , if the action is for example : public void GetMovie( [FromHeader] int code) { }
            // if we provided a value of "id" in the route, then it will not be binded to "code" , because they are not the same name and code will equal 
            // Zero as it's the default value for int



            // The action can have any datatype : string , void , .... and also can return types that inherits from interface "IActionResult"
            // Ex: if we returned a string from the Action (Response is a string) , how when the browser opens we find that it's a HTML page ????
            // This is called "DOM manipulation" 


            // When writing segments : 
            // 1 - Ordering         2 - No. of segments          3 - Defaults        4 - Constraints

            // 1 - Ordering :
            // We can change the ordering of "controller","action" , but it's better to be "controller" then "action" because action is contained in controller

            // app.MapControllerRoute(
            // 		name: "default",
            // 		pattern /*URL Path*/: "{controller}/{action}/{id?}"
            // 	);
            // URL : baseURL/Movies/GetMovie/10

            // app.MapControllerRoute(
            // 		name: "default",
            // 		pattern /*URL Path*/: "{action}/{controller}/{id?}"
            // 	);
            // URL : baseURL/GetMovie/Movies/10



            // The method "MapControllerRoute" uses 5 parameters: 2 mandatory (name and pattern [URL Path]) , and 3 optional (defaults, constraints, data tokens)

            // 1 - Defaults : object from anonymous type , we here specify the default values for the variable segments we have in the route 
            //                there is an old way in .NET framework , and a new way also , old way : 
            // app.MapControllerRoute(
            // 	    name: "default",
            // 		pattern /*URL Path*/: "{controller}/{action}/{id?}",
            // 		defaults : new {controller = "Movies" , action = "Index"}
            // 	);
            // 
            // New way : 
            // app.MapControllerRoute(
            // 	    name: "default",
            // 		pattern /*URL Path*/: "{controller = Movies}/{action = Index}/{id?}",
            // 	);

            // 2 - Constraints : object from anonymous type , we here specify the types of variable segments we have in the route 
            //                   there is an old way in .NET framework , and a new way also , old way : 
            // app.MapControllerRoute(
            //      name: "default",
            // 		pattern /*URL Path*/: "{controller}/{action}/{id?}",
            // 		constraints: new {id = new IntRouteConstraint()}        to specify that the id will be of type int
            // 	);
            // 
            // New way : 
            // app.MapControllerRoute(
            // 	    name: "default",
            // 		pattern /*URL Path*/: "{controller = Movies}/{action = Index}/{id:int?}",
            // 	);

            // Constraints : 
            // int       -> matches a 32-bit int value
            // alpha     -> matches strings , lowercase or uppercase latin alphabet characters (a-z , A-Z)
            // length    -> matches a string with a specified length or a range of lengths ex: length(6) or length(6,10)
            // maxlength -> matches a string with a maximum length , ex: maxlength(10)
            // minlength -> matches a string with a minimum length , ex: minlength(5)
            // max       ->	matches a integer with a maximum value , ex: max(10)
            // min       -> matches a integer with a maximum value , ex: min(5)
            // range     -> matches a integer within a range of values , ex: range(5,10)
            // regix     -> matches a regular expression, ex: regix([a-z])
            // long      
            // float
            // double
            // decimal
            // guid
            // bool 
            // datetime


            // important note with constraints :
            // app.MapControllerRoute(
            // name: "default",
            // 		pattern /*URL Path*/: "{controller}/{action}/{id:alpha?}"
            // );
            // if we types URL in browser : baseURL/Movies/GetMovie/10      ===> Error 404 , This localhost page can’t be found
            // that's because we specified the constraint on id that it's a string "alpha" , so we must type : baseURL/Movies/GetMovie/Ten
            // 



            // When not specifying a verb for an action , ex: get , post , put , delete .. then if we tried to write the URL in the browser
            // then it will work as "Get" verb .. but if we used Postman and tried to use any method "Get" , "Post" , "Put" , .. it will work 
            // without any problems ! unless we specify a verb manually using data annotations : [HttpGet] , [HttpPost] , [HttpPut] ,
            // [HttpDelete] . But note that in MVC controller we must use verbs "Get" and "Post" only , that's because the web browser
            // can execute methods with verb "Get" only , and HTML Form can execute verbs "Get" and "Post" only (as we discussed before) ..
            // but when it's an API controller then we can use any verb because javascript can execute any verb
            // ex: if we have an action with verb Post , if we tried to execute it from browser => Error 405 method not allowed


            // Important : Action overloading
            // if we have two actions having tha same name but with different return type and parameters , is this action overloading ?
            // No ! to overload actions they must have 1 - different verbs or 2 - different Action name attribute , otherwise Exception
            // Ex: baseURL/Movies/CreateMovie      ==> Exception , the request matches multiple endpoints
            // public ViewResult CreateMovie()
            // {
            //		return new ViewResult();
            // }
            // public OkResult CreateMovie(Movie m)
            // {
            //      return new OkResult();
            // }

            // 1 - different verb : 
            // [HttpGet]
            // public ViewResult CreateMovie()
            // {
            //		return new ViewResult();
            // }
            // [HttpPost]
            // public OkResult CreateMovie(Movie m)
            // {
            //      return new OkResult();
            // }

            // How to tell that this accept more than one verb ?
            // using data annotation : [AcceptVerbs("Get","Post")]

            // 2 - different action name attribute : 
            // public ViewResult CreateMovie()
            // {
            //		return new ViewResult();
            // }
            // [ActionName("ConfirmCreateMovie")]             // this is the name that must be written in the route 
            // public OkResult CreateMovie(Movie m)           // this is the name here in C# Code  
            // {
            //      return new OkResult();
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Action Return Types

            /* Start *****************************************************************************************************************/

            // We use some special return types for actions , they are : 
            // But why to use these special return types ? because we can specify the content type of the returned content , ex: text/html
            // and also the status code 

            // 1 - ContentResult :
            // ex: return the content of the wanted object 

            // 2 - BadRequestResult : 
            // ex: if the id = 0 then return a BadRequestResult 

            // 3 - NotFoundResult
            // ex: if the id = 100 then return a NotFoundResult


            // What if we want return more than one type in one action ? 
            // Then we must use the interface that all the special action return types inherit from : "IActionResult" and return any type
            // Note : We always use IActionResult as a return type for Actions ...

            // public IActionResult Test(int id)
            // {
            // 		if (id == 0)
            // 			return new BadRequestResult();
            // 
            // 		if (id == 100)
            // 			return new NotFoundResult();
            // 
            //
            // 		ContentResult result = new ContentResult();
            // 		result.Content = $"<h1> TEST Id = {id} as a text/html return type</h1>";
            // 		result.StatusCode = 500;               // here we specify the status code for the response
            // 		result.ContentType = "text/html";      // here we specify the returned response type 
            // 
            // 		return result;
            // }

            // All Action Results , their helper methods : 
            // 1 - ViewResult               View
            // 2 - PartialViewResult        PartialView
            // 3 - RedirectResult           Redirect
            // 4 - RedirectToRouteResult    RedirectToRoute or RedirectToAction   
            // 5 - ContentResult            Content
            // 6 - JsonResult               Json 
            // 7 - JavaScriptResult         JavaScript
            // 8 - StatusCodeResult         -- None --
            // 9 - UnauthorizedResult       -- None --
            // 10 - NotFoundResult          HttpNotFound
            // 11 - FileResult              File
            // 12 - EmptyResult             -- None --

            // What is the Helper Method ?
            // instead of returning an object from class , ex: ContentResult result = new ContentResult();  return result;
            // we use the helper methods :     return Content("Content" , "ContentType");   ex: return Content("<h1> HI </h1>" , "text/html");

            // So it's a better way to use helper methods 

            /* End ******************************************************************************************************************/

            #endregion


            #region Model Binding (Action parameters)

            /* Start *****************************************************************************************************************/

            // Model : Represents the underlying logical structure of data in a software application and the high-level class associated 
            //         with it. This object model doesn't contain any information about the user interface (action parameters are models)
            // Ex: public IActionResult GetMovie (int id) { ... }              // here the id is a model 
            // Ex: public IActionResult CreateMovie (Movie movie) { ... }      // here the movie is a model 

            // So it's not very accurate when we discussed before that the model represents the shape of the data in database tables

            // Model types : 
            // 1 - simple       ==> int id
            // 2 - complex data ==> Movie movie
            // 3 - Mixed data   ==> int id , Movie movie
            // 4 - Collection   ==> int[] arr 


            // What is model binding ? 
            // ex: the id or movie (last example .. ) from where they will get their values (who is the value provider for them) ?
            // Value providers (We Have Priorities here) :
            // Note : only first three work with priority , if we want to force binding from a place then use data annotations before parameters
            //
            // 1 - Form-Data --> as an Input , ex: if we have 2 CreateMovie actions , one HttpGet that doesn't take parameters that returns a 
            //                                     view that has HTML form , and the other HttpPost that take movie type parameter for submiting
            //                                     the form , when we sumbit the form the parameter takes the values from the input form 
            // 2 - Routing Data (segment in the route) --> ex: baseURL/Movies/GetMovie/10
            // 3 - Query string   --> Query parameter , after the "?" in the URL , ex: baseURL/Movies/GetMovie?name=Tarazan
            // 4 - Request Header --> must add data annotation [FromHeader] to Force the model take values from header (not by default takes)
            // 5 - Request Body   --> must add data annotation [FromBody] to Force the model take values from body (not by default takes)
            //                        This can be used only with complex object, simple data will not be binded , must be complex data ex: Movie 
            // 6 - Services       --> must add data annotation [FromServices] to Force the model take values from services that are registered
            //                        and work with dependency injection 


            // How to use postman to ensure that the last priorities are understood for you ? 
            // - in postman we have Headers , we can put data in it [Request Header]
            // - in postman we have Body , and we can choose form-data to simulate a HTML form [Form Data]
            // - in postman we have Body , and we can choose raw and choose Json or XML [Request Body]
            // - in postman we have Params , this is for adding query parameters [Query string]


            // model binding with mixed models with each other :
            // see action named as "Binding" in the controller ... 


            // model binding with collection : 
            // if the action takes a parameter of type array for example , then we can send the data to the array by :
            // see action named as "BindingCollection" in the controller ... 


            /* End ******************************************************************************************************************/

            #endregion


            #region Install client side library or front end library (Bootstrap)

            /* Start *****************************************************************************************************************/

            // in server side applications , we have Static Files , it's content doesn't change .
            // Ex: CSS files , Javascript files , images , videos , static HTML pages
            // These files must be inside a folder named with "wwwroot" , this folder is inside the project (after naming the folder with
            // this name it will have a new Icon ) .. In Angular this folder is called "Assets"
            // Inside this folder we make new folders , each for a file type , Ex: "CSS" folder to have all CSS files , ...
            // and also add inside "wwwroot" folder , a new folder called "lib" , that will contain any installed client side libraries ,
            // ex: Bootstrap , JQuery , ... 

            // So now we will install "Bootstrap" to be able to work with it 
            // self study : learn bootstrap from it's documentation: https://getbootstrap.com/docs/5.0/getting-started/introduction/

            // How to install the Bootstrap ? 
            // inside the "lib" folder , that's inside the "wwwroot" folder , right click -> Add -> Client-side library
            // then choose the provider , we usually use the "cdnjs" provider , then search on the library we want "bootstrap" , 
            // and by default it will choose the latest version ... then we choose the files we only want (choose specific files)
            // from css : we choose the "bootstrap.css" and "bootstrap.min.css" (minified version that we will use while production phase) 
            // from js  : we choose the "bootstrap.js"  and "bootstrap.min.js"  (minified version that we will use while production phase)
            //            and choose "bootstrap.bundle.js" and "bootstrap.bundle.min.js"  
            // Note : We have some files with ".rtl" --> right to left , if we want to use Arabic language 
            // Note : cdnjs => (Content delevery network) A server that has all the JS libraries that we want  
            // Note : After finishing the installation of the library , a new file is added "libman" (library manager) , this has all
            //        the information of libraries installed and it's versions and the provider also (cdnjs in the last example)

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with View and making a real controller

            /* Start *****************************************************************************************************************/

            // First of all we will add a new controller called "HomeController" , this will have "Home" , "ConstactUs" , "Privacy" , "AboutUs"
            // To make a controller by visual studio , right click -> Add -> Controller -> MVC Controller Empty 
            // and a new controller will be created (make sure that it's a MVC controller not an API controller) 


            // Now we must add a new folder in the project names as "Views" to contain all the views we have , inside this folser we 
            // have a folder for each controller (because one controller can have more then one view)

            // Adding a View : right click -> Add -> View -> Razor View (to have a basic structure for HTML page by default Head & Body)
            //                 view name , Templete "Empty" , no partial views , no layout pages
            // The view has extension .cshtml , because it's a razor view having C# code inside HTML

            // The default writing inside the view is HTML , if we want to write C# then we must use one of the next 2 ways :
            // 1 - One line : @int x = 10;
            // 2 - More than one line :       @{
            //                                    int x = 10
            //                                    string name = "Shoura"
            //                                 }

            // To add comments inside the view : 
            // 1 - HTML Comment  : <!-- HTML Comment -->
            // 2 - Razor Comment : @* Razor Comment *@          
            // 3 - C# Comment inside C# block :           @{
            //                                                /* C# Comment inside a C# Block */
            //                                             }


            // How to link the bootstrap ? 
            // in the HTML Head type : <link href="~/lib/bootstrap/css/bootstrap.css" rel="stylesheet" />
            // ~ in href -> geos to the wwwroot folder


            // after linking the bootstrap , and finishing developing the view , when running the application we will notice that
            // the bootstrap is not working in our view ..that's because by default the Kestrel will not serve the requests that want
            // static files (in browser -> inspect -> network -> css -> we will find that bootstrap.css is not found "status code 404")

            // to solve this problem we have 2 ways :
            // 1 - First we can copy the HTML Tag from the cnjs website for the version of bootstrap we want  and paste it inside the HTML head
            // then the kestrel will not serve this request as it's now not a static file in the app , paste it in the header :
            // <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap/5.3.3/css/bootstrap.min.css" integrity="sha512-jnSuA4Ss2PkkikSOLtYs8BlYIeeIK1h99ty4YfvRPAlzr377vr3CXDb7sb7eEEBYjDtcYj+AjBH3FLv5uSJuXg==" crossorigin="anonymous" referrerpolicy="no-referrer" />
            //
            // 2 - chage the defualt of Kestrel to eneble it serve requests of static files , done by configuring a
            //     middleware : .UseStaticFiles() 

            /* End ******************************************************************************************************************/

            #endregion


            #region Layouts and View Start

            /* Start *****************************************************************************************************************/

            // If we have more than one view having a common structure , then it's better to put the common code inside a layout and
            // use this layout in the views

            // inside the "Views" folder , we will add a new folder called "Shared" that will have all the layouts
            // to add a layout : right click on the folder -> Add -> New item -> search on layout -> Razor Layout

            // inside the layout insert the common code , in the HTML head or the HTML body , see layouts in folder "shared" and all the views
            // we created in folders "Home" and "Accounts"


            // we have a special razor page called "View Start" , code inside the view start will be put inside any view that we didn't 
            // specify a view for it .. ex: if we didn't specify the layout in a view then by default it will take the layout that is in
            // the view start , else if we specified a layout then it will be applied 
            // to add a view start -> Views folder -> right click -> add -> new item -> search on razor view start 


            // We can have more than one layout in our application 
            // we can have only one one View Start in one area (project can have more than one area "Self-Study")
            // we have only View Import in the project (discussed next region)

            /* End ******************************************************************************************************************/

            #endregion


            #region Tag Helpers , HTML Tags , HTML Helpers

            /* Start *****************************************************************************************************************/

            // See the layout called "_Layout.cshtml" for more details

            // 1 - HTML Tag : backend developers doesn't like writing html 
            // 2 - HTML Helper : Microsoft in old .NET Framework , added some methods that generates HTML code , but without writing HTML
            // 3 - Tag Helpers : easy as HTML code , introduced in .NET Core .. to use we must import for their namespace through :
            //                   "@addTagHelper * , Microsoft.AspNetCore.Mvc.TagHelpers" in the first line of the view (or in the "")
            // Tag helpers will be translated to HTML (inspect in the browser)
            // Note : if the action takes parameters -> asp-route-id="10"


            // Note : the namespaces that will be used in the views , we must put them inside "View Import" .. not in the view itself
            //        it's same as global usings 
            // to add a ViewImport -> in folder Views -> Add -> New Item -> Razor View Import 


            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
