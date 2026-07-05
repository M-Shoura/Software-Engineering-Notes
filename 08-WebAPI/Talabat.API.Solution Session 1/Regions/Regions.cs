namespace Regions
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // more about minimal APIs
            // What is Reflection ?
            // in APIs , how to differ between endpoints if they have the same verb
            // Routing APIs in .Net 6 : https://stackoverflow.com/questions/72063619/web-api-asp-net-6-routing-clarification
            // RESTfull APIs : https://aws.amazon.com/what-is/restful-api/
            // SOAP vs REST  : https://aws.amazon.com/compare/the-difference-between-soap-rest/
            // Monolethic VS Microservices : https://www.geeksforgeeks.org/monolithic-vs-microservices-architecture/
            // What is a Web Hook ?
            // ActionResult VS IActionResult 

            /* End ******************************************************************************************************************/

            #endregion


            #region Intro to APIs

            /* Start *****************************************************************************************************************/

            // .Net Platform that we can use to work in Web Development :
            //     1 - Asp.Net Core : Web applications and Web Services (most common used)
            //     2 - Blazor


            // Asp.Net Core :
            //     1 - Web Applications through => ASP.Net Core MVC (MVC Arch Pattern) and ASP.Net Core Razor Pages (MVVM Arch Pattern)
            //     2 - Web Services through     => ASP.Net Core Web APIs


            // Asp.Net Core Application : Can contain a part build by MVC , and a part build by Razor Pages , and a part build by APIs
            //                            So We configure the way the application will work with 


            // ASP.Net MVC => MVC : Model-View-Controller 
            // ASP.Net API => MC  : Model-Controller (the view is the client [Mobile App or Frontend Dev]) 


            // In MVC controller we have methods called "Actions" , that return the view that contains the data we want 
            // In API controller we have methods called "Actions" or "End Points" , that return the data we want as JSON File



            // Now We are going to start ASP.Net core Web APIs
            // API => Application Programming Interface
            // We use APIs (Services) to be able to be consumed by other programs may be not implemented in C# language , Ex: mobile
            // application or a Frontend 

            // The APIs are "Restful APIs" (traditional and most common used) , not "SOAP" or "GRPC" (will be discussed later)

            /* End ******************************************************************************************************************/

            #endregion


            #region First API Project

            /* Start *****************************************************************************************************************/

            // We will make an ASP.Net Core application with "API" templete , and we will use .NET 6.0 and in the last session we will
            // upgrade the version 

            // Don't use Top Level Statements -> this is done in the Kestrel (Console Application) project
            // Remember : The ASP.Net core application -> Two projects : 
            //                1 - Application code -> ( Web MVC , Razor Pages , Web API ) + internal web server
            //                2 - Kestrel -> console application 


            // Use Controllers (uncheck to use minimal APIs) : minimal APIs is used when we don't want to make controllers , just making 
            //                                                 the api and then return the result in the minimal API (discussed in the first
            //                                                 session of MVC i think .. )


            // the properties folder contains "launchSettings.json" that is not used in deployment , contains the two profiles ... the first
            // profile for running the application is the "Kestrel" named with the name of the project .. and the second profile is the 
            // "IIS Express" profile

            // Running with profile Kestrel is better because we have a console screen (black screen) that can be used for showing errors
            // and exceptions + also showing the query that is executed aganist the SQL Server Service in database without using the SQL
            // Profiler (starting from .Net 6.0)


            // the "appsettings.json" has the settings of the application that is changed over different environments (connection string of
            // the database is changed over different environments , token generation configurations also is changed over different
            // environments , ..... ) . We can have more than one appsettings file (the number of environments we have)

            // The API controller inherits from "ControllerBase" , but the MVC controller inherits from "Controller" that inherits from 
            // "ControllerBase" also

            // The API controller class has two important attributes (data annotation) on it :
            // [ApiController]         => To specify that this is an API controller
            // [Route("[controller]")] => The most common used way for making routing in API is per controller (in MVC this was not the way
            //                            we work with , we used a generic route that takes a controller name , then action name , then id
            //                            that is optional). Note : [Route("[controller]")] => any controller
            //                                                      [Route("controller")] => controller static word (wothout square brackets)
            // Note : Controller name must end with "Controller"


            // Endpoints or Actions inside the API controller : 
            // we can use a data annotation like this [HttpGet(Name = "XYZ")] and then we will use this name instead of the name of the 
            // action or endpoint ... and to consume this endpoint the verb must be "GET" , what if we have more than one function that
            // are with Verb "Get" in the controller ? then they must have different parameters to differ between them 


            // Remember : The ASP.Net core application -> Two projects : 
            //                1 - Application code -> ( Web MVC , Razor Pages , Web API ) + internal web server
            //                2 - Kestrel -> console application 

            // The kestrel starting from .Net 6.0 now is in the program file only (without the StartUp file ... ) 
            // now in the program class we configure the services using an object from WebApplication.CreateBuilder then build this web
            // application then configure the middlewares then run the app

            // 1 - var webApplicationBuilder = WebApplication.CreateBuilder(args); 
            // 2 - then configure the services here "allow dependency injection" ( "ConfigureServices" method in .Net 5 and before ) 
            // 3 - var app = webApplicationBuilder.Build();
            // 4 - then add the middlewares here ( "Configure" method in .Net 5 and before ) 
            // 5 - app.Run();

            // Note : Before building the web application ( "ConfigureServices" method in .Net 5 and before ) we add the services to the
            //        Dependency Injection container , also we can configure other things : 
            //            1 - Services        => adding services to the Dependency Injection container
            //            2 - Environment     => knowing the environment that we are in 
            //            3 - Configuration   => to configure the app settings
            //            4 - Web Host        => Discussed later 
            //            5 - Host            => Discussed later 
            //            6 - Logger          => Discussed later 

            // Note : Middlewares ordering is very important , cannot make "UseRouting()" the last middleware added 

            /* End ******************************************************************************************************************/

            #endregion


            #region Postman

            /* Start *****************************************************************************************************************/

            // Note : We can use Swagger or Postman for documenting our APIs

            // Install Postman , New Workspace , a new workspace contains collections and APIs and Environments and mock servers and ....
            // we will discuss now the collections , For each Project we have a Collection for it ... and for each module we have a folder
            // inside the collection , Add Request with the verb and specify the URL and start !!

            // Note : to make a global variable in Postman (ex: global variable that has the value of the baseURL instead of writing it many
            // times ... ) so double click on the Collection , and then go to "Variables" and add the variables you want 
            // and when using it in the URL in postman , to use the variable (ex: {{baseUrl}}/api/Products)

            /* End ******************************************************************************************************************/

            #endregion


            #region RESTfull VS SOAP Services 

            /* Start *****************************************************************************************************************/

            // In ASP.NET Core , we can build web APIs that are "RESTfull" Architecture. Can work with SOAP, but it is not their primary
            // focus and mainly designed for building RESTful services

            // Must to Visit :
            // RESTfull APIs : https://aws.amazon.com/what-is/restful-api/
            // SOAP vs REST  : https://aws.amazon.com/compare/the-difference-between-soap-rest/

            // REST works only with HTTPS
            // REST Supports XML , JSON , Plain Text , HTML

            // MVC Controllers , the actions inside it must be ("GET" => for get/getAll) or ("POST" => for create & update & delete),
            // because the web browser only supports "GET", and the HTML form supports "GET" and "POST" only (for create update delete) 

            // BUT

            // In Web API controller , the consumer for the actions/endpoints is a frontend dev or mobile application dev then all verbs 
            // can be used (GET , POST , PUT , DELETE)

            // Dummy controller : API Controller inherits from ControllerBase and has data annotation [ApiController]
            // 

            // [ApiController]
            // [Route("[controller]")]                           // Square Brackets
            // class ProductsController : ControllerBase
            // {
            //     [HttpGet]
            //     GETProducts() { }
            // 
            //     [HttpGet("{id}")]                             // Curly Brackets
            //     GETProductById(int id) { }
            // 
            //     [HttpPost]
            //     AddProduct(Product Item) { }
            // 
            //     [HttpPut]
            //     UpdateProduct(Product Item) { }
            // 
            //     [HttpDelete]
            //     DeleteProduct(Product Item) { }
            // }

            // To execute an endpoint choose the verb : 
            // baseURL/Products               Verb => Get (first one without id)   different parameters to differ between them
            // baseURL/Products/10            Verb => Get (second one with id)     different parameters to differ between them
            // baseURL/Products               Verb => Post 
            // baseURL/Products               Verb => Put 
            // baseURL/Products               Verb => Delete

            /* End ******************************************************************************************************************/

            #endregion


            #region GraphQL and gRPC

            /* Start *****************************************************************************************************************/

            // GraphQL: 

            // Graph Query Language : Tools that is made and used by Facebook
            // if we have a page in our frontend that consumes more than one API , ex: in the same page show all the categories , brands and
            // products ... then to consume these APIs we must send 3 requests to the server .. then to request all the APIs in one time we
            // use the GraphQL 



            // gRPC: 

            // Other shape for an API , Commonly used with Microservices applications 
            // RPC => Remote Procedure Call 
            // Was Developed By Google 

            /* End ******************************************************************************************************************/

            #endregion


            #region Onion Architecture 

            /* Start *****************************************************************************************************************/

            // in this project , we will work with the Onion Architecture Pattern 

            // 1 - Domain Layer / Core Layer : Which is a Class Library , contain Domain Models (classes that represents the tables in
            //                                 Database) , and also ALL the interfaces (contracts) ... The project but not Implemented  
            // 
            // 2 - Repository Layer : Which is a Class Library , we work here with Generic Repository design pattern and also the Unit
            //                        of work design pattern , Contains the DbContext class (We could have more than one repository layer
            //                        incase we have more than one DbContext class and more than one database)
            // 
            // 3 - Service Layer : Which is a Class Library , Here we have all the Services (ex: payment services , caching services , .. ) 
            // 
            // 4 - Presentation Layer : Two projects , The API that we will implement and MVC project for Admin Dashboard (Workshop)


            // So now add the projects in the solution (with .Net 6.0) ... 
            // 1 - Talabat.Core                    => Class Library
            // 2 - Talabat.Repository              => Class Library
            // 3 - Talabat.Service                 => Class Library
            // 4 - Talabat.API (Added before)      => ASP.NET Core Web API


            // Note : The naming can be changed later ... 
            // Repository layer => Infrastructure Layer
            // Services Layer => Application Layer

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with Product Module

            /* Start *****************************************************************************************************************/

            // We always start with the Core Layer / Domain Layer and build the application ... 

            // add folder "Entities" in Core project 
            // inside it add the Base Entity that all the entities will inherit from it
            // now add the 3 Entities of the Product Module in new Folder "Products" : 1 - Product , 2 - ProductCategory , 3 - ProductBrand
            // (Don't miss making navigational properties for relationships between the entities)

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting With DbContext , Migrations , Update Database and Data Seeding

            /* Start *****************************************************************************************************************/

            // The DbContext will be in the Repository Layer , so we will make a folder inside the repository layer called "Data" ,
            // then add the DbContext class "StoreDbContext" .... 
            // install the package "Microsoft.EntityFrameworkCore" -> For SQL Server, Azure SQL Database, SQLite, Azure Cosmos DB, MySQL,
            //                                                        PostgreSQL, and other databases through a provider plugin API.
            // or
            // install the package "Microsoft.EntityFrameworkCore.Relational" ->  For relational database providers
            // or
            // install the package "Microsoft.EntityFrameworkCore.SqlServer" -> For SQL Server Only .. 

            // Note : When working in the DbContext class , we notice that we want to allow the dependency injection for the DbContext 
            //        in the API Project .. must we install the package "Microsoft.EntityFrameworkCore.SqlServer" again in the API Projects?
            //        No, we can add a project reference inside the API project for the Repository Project

            // Note : When adding the DbSets in the StoreDbContext , we must add reference inside repository Project for the Core project

            // Now write the Fluent APIs , make configuration classes 

            // Now add the Migration (From the project that has the Connection string "APIs" project) , so install the package "Tools" in the
            // API project (APIs is the startup project , and when adding the migration choose the Repository to be the "Default Project")

            // Now Update Database , but we will use a new way rather than writing "Update-Database" in the Package manager console ... 
            // that's in case when running the application then apply any pending migration (without opening the package manager console ,
            // in case we deploy on a server and we don't have Visual Studio !)
            // How ? 
            // By asking the CLR to provide an object from the DbContext EXPLICITLY ... (See the program class , after configure services)

            // Now seed the data from the given files , see StoreContextSeed class in Data Folder .. 

            /* End ******************************************************************************************************************/

            #endregion


            #region Generic Repository and Products Controller

            /* Start *****************************************************************************************************************/

            // First add the interfaces in the "Core" Project ... Add the interface IGeneric Repository
            // Then in "Repository" project add the Generic Repository class that implements the interface
            // Till now we need only "GetAll" and "GetById" .... because "create/update/delete" will be inside the MVC controller of the
            // admin dashboard ...

            // We will not make repositories for Product or other entities .. the controller of Products will work direct with the 
            // Generic Repository

            // Then add the controller in the API Project .. "BaseApiController" has the two attributes so we will inherit from it

            // Note : we can add the dependency injection like this instead of adding it multiple times with different entities : 
            // webApplicationbuilder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
