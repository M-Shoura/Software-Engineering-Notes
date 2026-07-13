using Microsoft.EntityFrameworkCore;
using My.Models;
using My.RepoServices;

namespace My
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // ---------- DI Container -----------------

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext in the DI Container
            // if anyone request service of type MainDbContext then create and inject object from it using the options specified here ....
            builder.Services.AddDbContext<MainDbContext>(options =>
                            //options.UseSqlServer("Data Source=.;Initial Catalog=Demo8_DB;Integrated Security=true;Trust Server Certificate=True;")
                            //options.UseSqlServer(builder.Configuration["ConnectionStrings:myConnection"])
                            options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection"))
                    );

            // Register Repo Services in the DI container, the next means :
            // anyone request a service of type IStudentRepoService then inject object from StudentRepoService "with scoped lifetime"
            // and same with department
            builder.Services.AddScoped<IStudentRepoService, StudentRepoService>();
            builder.Services.AddScoped<IDepartmentRepoService, DepartmentRepoService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();


            // Regions : 



            // Services: (Create->Contain->inject)
            // 
            // - Service Types:
            // 1 - Built -in, Contained Service(IConfiguration..IHostingEnvironment)
            // 2 - Built -in, Not Contained Service(ControllersWithViews..DBContext)
            // 3 - Custom, Not Contained Service(StudentService, DepartmentService)




            // The way of managing the controller in the previous sessions was not the optimal way .. in this session we will enhance the way we work with.
            // - No composition : inject the DbContext in the ctor of the controller, and put DbContext class in the DI container (it's NOT by default there !!)
            // - Single Responsibility : we do every thing in the controller actions and this is wrong !! 
            // - having new layer called "Repository" , that manages connection with the DB , managing DAL , write all queries here , DbContext class , Entities , 
            //   this helps in achieving S and O Solid principles as it's now more modular and any change in any layer will not affect the other 

            // so why do we need this extra layer ? Repository pattern ? SELF STUDY 

            // starting building the DbContext class, Note That we will use the second ctor overload of DbContext class , that allows us to apply DI
            // (DbContext options) is injected in the Ctor

            // - Register DbContext in the DI Container (in program class) : 
            // - if anyone request service of type MainDbContext then create and inject object from it using the options specified here ....
            // builder.Services.AddDbContext<MainDbContext>(options =>
            //                 options.UseSqlServer("Data Source=.;Initial Catalog=Demo8_DB;Integrated Security=true;Trust Server Certificate=True;")
            //         );


            // Note : we can put the connection string in the appsettings.json , it's recommended to put it in the "ConnectionStrings" section , see the 
            //        appsettings here ... 

            // self study : builder.Services.add XXXXXXXXXXXXXXXXXXX , know what can be added 


            // now make a Repository for Student and also for Department , and use them inside the controller as we did.


            // when adding a service in the DI container , we can add it with three different lifetimes : 
            // 1 - AddTransient : "Per Request" Transient lifetime services are created each time they're requested from the service container. This lifetime works
            //                    best for lightweight, stateless services.
            // 2 - AddScoped : "Per Client Session" scoped lifetime indicates that services are created once per client request (connection). In apps that process
            //                 requests, scoped services are disposed at the end of the request.
            // 3 - AddSingleton : "Per Application" Singleton lifetime services are created the first time they're requested, Every subsequent request of the
            //                    service implementation from the dependency injection container uses the same instance. (one instance for the whole application
            //                    requests from all client's sessions) Like "Static" object.

            // Note : When using Entity Framework Core, the AddDbContext extension method registers DbContext types with a scoped lifetime by default.
            //        So if you try to register your services as "Singletone" while working on DB, it will exception because you can't keep Single instance while
            //        DbContext is Scoped by default.


            // self study more : scoped , one per request or one per session ?????????????????

            // remember : what is "nameof()" ????????



            // --------------------------------------------------------------------------------------------------------------------------------------------------


            // Part 2 : 

            // in the launchSettings.json , we have enviromentVariables that has key called "ASPNETCORE_ENVIRONMENT" that tells us the environment that we 
            // are working in now , so that we can change the behaviour of the application and how it will work (used database , used exception handling middlware,
            // read from local files or from CDN , ... ) and also an important use : using some tag helpers that can be used in the views , these tag helpers 
            // don't have the same name of plain HTML tags and used to change the view based on the environment that we are in now , ex: 
            // - environment : tag helper used to change the view or appearance of the website based on the environment that we are in now .
            //                 Note : specify the environment in the "include" attribute.
            //                        OR
            //                        specify all environments except in "exclude" attribute.
            //   ex : 

            //  <environment include="Development">
            //     <div style="color:red">
            //         <h1> We are in development environment </h1>
            //     </div>
            // </environment>
            // 
            // <environment include="Production">
            //     <div style="color:red">
            //         <h1> We are in Production environment </h1>
            //     </div>
            // </environment>
            // 
            // <environment exclude="Production, Staging">                          // all other environments except "Production" and "Staging"
            //     <div style="color:red">
            //         <h1> We are in environment other than Production and Staging </h1>
            //     </div>
            // </environment>



            // -------------------------------------------------------------


            // Bundling and Minification : 

            // They are two different concepts , we can do one of them or both of them ... 

            // Bundling : This system reduces requests to your site by combining several individual script references or CSS request into a single request.
            // The problem : when the browser sends two separate requests to load two different JS/CSS/.... files. (Too many requests)
            // Solved by bundling : put more than one file in one bundle and request them in one time. This minimizes the trips to the server so the solution runs
            //                      faster.

            // Minification : shortening variable names and removing whitespace and comments to make the file smaller in size so it's easier for transfering.

            // So ASP.NET MVC 4 (and later) supports the same bundling and minification framework included in ASP.NET 4.5.


            // we added some style files (CSS files) in wwwroot folder so we will apply bundling and minification on it : 
            // To make bundling : Add a json file in the solution / project and tell who will be in one bundle (don't change the name , must be with this 
            //                    specific name) : 
            // - bundleconfig.json : inside it make an array that contains objects , and inside the object make "inputFiles" with the name of files that we want
            //                       to put them in one bundle , and in "outputFileName" give the name of the output bundle file (see bundleconfig.json)

            // To make minification : in the same json file called bundleconfig.json , add "minify": {"enabled": true} because the default is false;


            // Now to apply the settings we configured in that file bundleconfig.json , we must install a package that looks for a json file with this name and 
            // applies it , this package is called "BuildBundlerMinifier", note that when we installed this package , the new file (output of bundling) that we
            // created in a specific path in WWWROOT is created successfully.


            // ---------------------------------------------------------------------------------------------------------------


            // we knew how to send data from the model to the view using 3 ways , we will know the forth way now "View Model" : 
            // 1 - ViewData
            // 2 - ViewBag
            // 3 - Model property
            // 4 - View Model (NEW WAY)


            // View Model : it's customizable , if we want sertain things from each object (ex: instead of sending the main object as Model and other objects
            //              in the viewbag) , so we can use only the properties we want from all models and then send it to the view , so it's a Customized 
            //              model for this view 

            // So the ViewModel is same as DTO ! 

            // So using ViewModel and Model are the best ways for sending the data from the controller to views (and views that are built with ViewModel are also
            // strongly typed views , ViewModel == Model but Model uses an existing type but ViewModel has a customized type)

            // so to make a ViewModel , make a class with the specific properties we want , then use this inside any controller !
            // ex: see the Dummy Controller called "testDataController"


            // Important note : for auto generation of Views (for a specific type as we do in last 4 or 5 sessions) , to make scaffolding applicable then the 
            //                  type we scaffold must have a PK , so if our type doesn't have a PK then we can make the view manually , or for the case of 
            //                  the view model , we can make any thing as a Pk with the Data annotation [Key] and this is useless and will not make any effect 
            //                  but it's used to make automatic views scaffolding ! 


            // ---------------------------------------------------------------------------------------------------------------


            // Partial View : it's a part of the view , remember "Render Page" that we took in the first day , it's same as IFrame in html , showing a page inside another page , 
            //                so the partial view is a view that will bu put inside another larger view.

            // The partial view : 
            // - Doesn't have a Layout , the layout is applied on the larger view
            // - It cannot exists by it self , it's a part of another view 
            // - It uses the Model of the larger View , as it's a part of the larger view , so it's strongly typed view

            // Ex: the Create View and Edit View is almost the same with minimal changes , so why don't put the shared part in a partial view and show it with each operation view ? 

            // see the partial View : "_CreateEditStudent_PartialView" in students view folder (Create a new Razor View)

            // and inside the create and edit views : use tag helper <partial name="PartialViewName" model="Model">

            // Don't miss adding @model My.Models.Student in the top of the partial view if we want it , and also add any thing we want with the ViewBag here in the partial view , 
            // as they now are not used in the actual large view.


            // so why do we use Partial Views ? 
            // - re-using code 
            // - making large views show smaller or making large views partitioned on more than one partial view , ex: making a partial view for the navbar and another for the 
            //   body and another for .... 

        }
    }
}
