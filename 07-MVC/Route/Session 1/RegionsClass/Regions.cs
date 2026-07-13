namespace RegionsClass
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // mvvm
            // How .net blazor web assembly project works ?
            // right click and inspect in the web browser
            // what is minification and bundeling
            // URI , URN , URL
            // request header in reuqest message HTTP
            // response header in response message HTTP
            // in process hosting : https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/in-process-hosting?view=aspnetcore-9.0
            // out of process hosting : https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/out-of-process-hosting?view=aspnetcore-9.0

            /* End ******************************************************************************************************************/

            #endregion


            #region General

            /* Start *****************************************************************************************************************/

            // .Net is a platform that we can use to build any thing "A Unified Development Platform"
            // 1 - Web ==> ASP.Net , Blazor  : Web Applications or Web Services (APIs)
            // 2 - Desktop ==> .NET MAUI , WPF , WindowsForms
            // 3 - Mobile ==> .NET MAUI , XAMARIN 
            // 4 - Cloud ==> Azure
            // 5 - Gaming ==> Unity
            // 6 - IOT ==> ARM32 , ARM64
            // 7 - AI ==> MLNET , .NET For Apache Spark


            // .NET as a SDK (.NET Runtime) :
            // 1 - Common Base Libraries : Base classes (ex: System)
            // 2 - CLR (Infrastructure of the .NET Runtime)
            //       - Runtime Components : JIT Compiler , Garbage Collector
            //       - Compilers : Roslyn
            //       - Languages : C# , F# , VB


            // Note :
            // Server side : All the process done in the server side
            // Client side : All the process done in the client side by the Web browser


            // Web : 
            // 1 - ASP.NET Core (cross platform of the ASP.NET framework) : commonly used 
            //      - we can use ASP.Net Core to build three Projects : 
            //           1) MVC            (Server Side Application , Multiple Pages [every request gets a page]) 
            //           2) Razor Pages    (Server Side Application , Multiple Pages [every request gets a page])
            //           3) Web API        (Consumed in Mobile and Front-End Apps)
            //
            //              - What to use , MVC or Razor Pages ? => they differ in the Architectural pattern :
            //                   MVC : MVC "Model View Controller"  ...  Razor Pages => MVVM (Model View View Model) 
            //                   Separation of concerns is better in MVC , so we usually use MVC rather than Razor Pages
            //                   But in the last session , we will use Razor Pages , as the Security module is implemented
            //                   with it (sign in , sign out , forget password , two factor authentication , .. ) so 
            //                   to avoid implementing it from scratch we will use Security module built with Razor Pages
            //                   So the ASP.NET Application can contain any of the three project types ! 
            //
            //
            // 2 - Blazor : New introduced in .Net 3.1
            //      - we can use .Net Blazor to build two Projects : 
            //           1) Server App   ( Multiple Pages Application )
            //                - it's same as .NET Core MVC , differes from MVC that Blazor Server App opens a SignalR connection between the server and
            //                  the client (web browser) , so the application is Real Time (any update is shown automatically without requesting)
            //           2) Web Assembly ( Client Side application , Single Page )
            //                - Typical to Angular
            //                - Only modern browsers supports this type of projects 
            //
            //



            // MVC : One of ASP.NET Products , it's an architectural pattern seperates an application into three main components (model , view , controller)
            //       and it's a server side multiple pages application
            //       1 - Model : class that represents the data in our database tables
            //       2 - View  : The HTML Page (contains C# code) that will be returned for the used who did the request (it's a razor page ".cshtml")
            //                   Note : response in MVC => View , response in APIs => JSON
            //       3 - Controller : 
            //                       Class name must end with "Controller" , ex: ProductController
            //                       Inherits from class called "Controller" , that inherits from class called "ControllerBase"
            //                       Note : API controller inherits directly from the class called "ControllerBase"
            //                       Regularly having 8 functions (named as Actions "in MVC" / End Points "in APIs") :
            //                          - GetAll  : it's usually named as "Index" because it's the landing page (home page) of the controller , ex: Product
            //                          - GetById : gets the Id and returns the item with this Id if exists
            //                          - Create  : 2 Functions , First route us to the create view , Second submits the first create in the Database  
            //                          - Update  : 2 Functions , First route us to the update view , Second submits the first update in the Database  
            //                          - Delete  : 2 Functions , First route us to the delete view , Second submits the first delete in the Database  


            // API : (MV : Model Controller ) We have many architectures => SOAP , REST , GRPC , GraphQL 


            // Difference Between Design Patterns and Architectural Patterns : 
            // Design Patterns : Solves a known problem in the code in different business scenarioes , Ex: Singleton design pattern for
            //                   disabeling multiple object creation
            // Architectural Patterns : Solves a problem in the overall design of the project , the Architecture that the project will be built on


            // What is deployment ? After development we will install out developed app on the server, this server has a IP address that is visible 
            //                      on the internet to be accessable to the clients (users) . we can deploy on Physical server , or a virtual machine
            //                      or using a hosting provider (not recommended with .Net)



            // Client Side code (web browser can understand it) : HTML , CSS , JavaScript
            // Server Side code : ASP.NET , PHP , NodeJs , Python 


            // Client Server App : Client uses a web browser to make a HTTP Request and send it to the Server that the web application is deployed on it
            //                     Then the server will process the request , get data from database and binds this data with HTML page with CSS , JS files
            //                     And then return the HTTP Response to the Client ...


            // What is SignalR ? it's just a library or a tool used to make the application "Real Time". SignalR must be handeled in the front end and also
            //                   the back end

            /* End ******************************************************************************************************************/

            #endregion


            #region HTTP Protocol

            /* Start *****************************************************************************************************************/

            // Client : End User or Consumer (user that has a PC or mobile : End user / client that will use a server side app or a client side application)
            //                               (Frontend / Mobile teams : End user / client that will use an API)
            //          It's not important to have an IP Address that is visible to everyone
            // Server : Computer having more powerfull hardware to be able to serve clients as we want and handle their requests , we install and deploy
            //          the Web Application on it . Must Have an IP that is visible through the internet

            // interaction between server and clients is done through some protocols :
            // 1 - HTTP protocol : HyperText Transfer Protocol is an application protocol for distributive, collaborative and hypermedia information system
            //                     protocol for transfering HTML pages from server to client .. It's a stateless protocol (don't know any thing until sending
            //                     a request to the server) we have http and https , https has the Security layer (SSL or TLS) as an additional layer 
            //
            // 
            // 2 - FTP protocol  : File Transfer Protocol , for transfering files between client and server (upload and download)
            //
            // 3 - TCP protocol  : Transmission Control Protocol , used in SignalR 
            // 
            // And Many other protocols ....... 


            // HTML Page that is sent to the client from the server contains many resources such as (images, videos, Audio, Css Files , JS Files , ...)
            // embedded in the HTML Page ... so the client doesn't send one request but many requests because there are many resources


            /* End ******************************************************************************************************************/

            #endregion


            #region URL

            /* Start *****************************************************************************************************************/

            // URI : Uniform Resource Identifier , contains the two next (URL and URN)
            // URL : Uniform Resource Locator 
            // URN : Uniform Resource Name

            // Request will be transfered through http or https

            // Ex: http://    Netflix.com        /Movies/GetMovie   ?id=5&name=abc
            //    protocol  Host (domain) name      URL Path          Query String

            // Ex:  http://      www.        google           .com
            //     protocol   subdomain   domain name   top level domain (TLD)

            // Note : The host name must be unique (we cannot find amazon.com again , but we can find amazon.edu for example .. )
            // Note : The top level domain (.com , .net , .edu , ..) is important for the SEO "Search Engine Optimization"

            // Base URL : http:// Netflix.com 

            /* End ******************************************************************************************************************/

            #endregion


            #region HTTP Request Messages

            /* Start *****************************************************************************************************************/

            // Any HTTP Message has two parts : Header and Body 


            // The Web browser creates the HTTP Request Message after we enter the URL we are searching for , this message is created from the URL we 
            // entered and also the default settings of the Web Browser (shown in the Request Headers below .. )

            // Header of Request Message : 
            // 1 - Request Line
            //       - Method : Get , Post , Put , Delete , ......
            //       - Path : ex => Movies/GetMovie 
            //       - Protocol Version : HTTP/1.1
            //        
            // 2 - Request Headers 
            //       - Host : Host name or domain name , ex: www.Netflix.com         (From URL)
            //       - Accept : image/gif , image/jpeg , */*  "anything/anything"    (From default settings of the Bowser)
            //       - Accept-Language : en-us                                       (From default settings of the Bowser)  
            //       - User-Agent : Mozilla/4.0  "user web browser"					 (From default settings of the Bowser)
            //       - Authorization : Contains the Token 
            //       - Many others .............


            // Body of Request Message :
            // if the method was "Get" then the body will contain the Query String , ex: id=5&name=xyz
            // if the method was "Post" then the body will not be shown 



            // Important table : 

            // Method       ||    JavaScript   ||    HTML Form   ||    Browser
            // Get          ||       Yes       ||      Yes       ||      Yes
            // Post 		||		 Yes       ||      Yes       ||      No
            // Put 			||		 Yes       ||      No        ||      No
            // Delete		||		 Yes       ||      No        ||      No





            // Very Important : we've discussed the controller in MVC in last regions , it has 2 create functions .. first route us to the create view ,
            //                  second for submits the first create in the Database .. so when we type "Netflix.com/Movies/Create" in the browser , which
            //                  create we will go to ? We will go to the create Action method that has a verb "Get" because this is a web browser and ONLY 
            //                  Supports "GET" Method

            // Basic 8 functions in the MVC Controller : 
            //                          - GetAll , Verb => Get
            //                          - GetById , Verb => Get
            //                          - Create  : 2 Functions (Actions)
            //                              - First route us to the create view , Verb => Get
            //                              - Second submits the first create in the Database , Verb => Post 
            //                          - Update  : 2 Functions (Actions)
            //                              - First route us to the update view , Verb => Get
            //                              - Second submits the first update in the Database , Verb => Put
            //                          - Delete  : 2 Functions (Actions)
            //                              - First route us to the delete view , Verb => Get
            //                              - Second submits the first delete in the Database , Verb => Delete

            // In MVC Controller we cannot use Put or Delete , as they are not supported in HTML Form or Web Browser , so we will use only Get and Post
            // and Post will be used for Add , Update , Delete 

            // If the controller was an API controller , then we could use any of the methods (Get , Post , Put , Delete) because they are all 
            // supported with JavaScript and JS is used by the FrontEnd & Mobile Developers (the consumers of APIs)

            // Note : for example if we used "Get" method with Account controller ... this will make the Email and Password (body of the request) shown 
            //        in the Query String , so in this case it's important to use "Post" method to avoid this problem (use proper method for situation )


            /* End ******************************************************************************************************************/

            #endregion


            #region HTTP Response Messages

            /* Start *****************************************************************************************************************/

            // Any HTTP Message has two parts : Header and Body 


            // Who creates the Response message ? The Backend Developer in the server side

            // Header of Response Message :
            // 1 - Status Line 
            //       - Status Code : (1xx => Informational , 2xx => successful , 3xx => Redirection , 4xx => client error , 5xx => server error)
            //       - Protocol Version : HTTP/1.1
            //
            // 2 - Response Headers 
            //       - Date 
            //       - Server : Web server (IIS for windows or Apache/Ngnix for Linux)
            //       - Content-Type : text/html
            //       - Many others .............



            // Body of Response Message : 
            // Contains the HTML Page

            /* End ******************************************************************************************************************/

            #endregion


            #region ASP.NET Framework

            /* Start *****************************************************************************************************************/

            // ASP.NET Framework , was in the old .Net Framework
            // ASP.NET Framework had Three projects for server side applications (multiple pages) 
            // 1 - ASP.NET Web Forms (not continued in .Net Core ... )
            // 2 - ASP.NET Web Pages (continued in .Net Core and Renamed to "Razor Pages")
            // 3 - ASP.NET Web MVC   (continued in .Net Core)


            // In ASP.NET Core we have Three projects 
            // 1 - ASP.NET Razor Pages "MVVM"   (for server side applications , multiple pages)
            // 2 - ASP.NET MVC                  (for server side applications , multiple pages)
            // 3 - ASP.NET Web APIs             (for single page application)

            /* End ******************************************************************************************************************/

            #endregion


            #region Deployment in .NET Core VS Deployment in .NET Framework

            /* Start *****************************************************************************************************************/

            // Development : 
            // - in .NET Framework , we couldn't develop on operating system other than Windows , because there was only .NET SDK for windows OS
            // - in .NET Core , we could develop on any operating system , because we have .NET SDK for all operating systems 

            // Deployment : 
            // - in .NET Framework , we must deploy on a server having windows OS , becuse we can only deploy on a web server for windows
            //   (IIS web server => Internet Information Services)
            // - in .Net Core , we will discuss it now ...

            // To install the IIS on our device running on Windows OS : 
            // Control Panel -> Programs -> Turn Windows Features ON or OFF -> Internet Information Services (by default not installed) -> 
            //                           -> Search on IIS Manager


            // Note : In Visual Studio , we have a IIS Express , to make the deployement easier so we can test our application functions ,
            //        In Visual Studio Code , we have "Live Server" Extension , same as IIS Express in visual studio .. deploy on a port on our device 
            //        We deploy on the IIS windows server after finishing the development phase


            // Windows default Post = 80 , till port 1024 , they are all taken by the windows services



            // Deployment in .Net Framework in Depth :
            // We couldn't deploy a .Net Framework application on a OS other than Windows , because the IIS is a Windows feature .. and the Linux web servers 
            // Apache and Ngnix don't have a reference to .Net Framework (and Apple doesn't have an OS for servers .. )


            // Deployment in .Net Core in Depth :
            // 1 - First Hosting Model : (Out of Process)
            //		Now we could deploy on any server running on any Operating System (Windows OS => IIS , Linux OS => Apache or Ngnix) , How ? the IIS and the
            //		Apache and Nginx doesn't have A reference to .Net Core (only IIS has a reference to the old .Net Framework) ... The web server will act as 
            //		a reverse proxy server (External Web Server) (only deploying the application on , NOT responsible for handeling requests) .. so who will 
            //		be responsible for handeling the requests ? Our ASP.NET Core application ! The ASP.NET Core application is devided into two parts , 
            //		the Application code (MVC / API / Razor Pages) + The Internal Web Server (Kestrel "It's a console application") . The Kestrel handels the
            //		requests , through the Pipelines or middelwares inside it , we have many middlewares and we can make our own middlewares also .. The request
            //		must pass all the middlewares first to proceed to the application code. Note : some middlewares work on the requests , and others work on
            //		the responses. Ex for middlewares : UseRouting middleware that determines the path that the request will go through in the application code 

            //		Note : We must install a hosting bundle to have a reference from IIS to .NET Core application (as we discussed that there is no reference)


            //		The client sends a request , the Reverse proxy server (IIS, Apache, Ngnix) forwards the request to the internal web server (Kestrel)
            //		then if the request passed all middlewares in the Kestrel , the application code will be executed for this request , and will return the
            //		response back to the Kestrel that also the response must pass the middlewares in the Kestrel .. the Kestrel returns the response to the 
            //		Reverse proxy server that sends the request to the client 


            // 2 - Second Hosting Model : (In Process)
            // Kestrel is internet facing , it takes the request from the client directly , so we don't have the reverse proxy server that was in the 
            // first hosting model ... it's called Self-Hosted. It's recommended and better than the first hosting model 


            /* End ******************************************************************************************************************/

            #endregion


            #region Request Response life cycle

            /* Start *****************************************************************************************************************/

            // Request Response life cycle : 
            // the user sends a HTTP request to the controller , the controller uses the model for getting the wanted data for the request and
            // then the model returns the data wanted ... the controller sends the data to the view that presents the data for the client through 
            // thr HTTP response


            /* End ******************************************************************************************************************/

            #endregion


            #region ASP.NET Core Project Structure 

            /* Start *****************************************************************************************************************/

            // ASP.NET Core application consists of : Application code & Kestril

            // ASP.NET Core 5.0 and before project structure : 
            // Kestrel devided into two files , Class "program" , and the configurations of kestrel in Class "startup"



            // After ASP.NET Core 5.0 (6.0 , 7.0 , 8.0 , ...) :
            // Kestrel is in one file , Class "program" that also contains the configurations of kestrel


            // When making a new project , we can choose to Configure HTTPS .. That means when deployment we will deploy on two ports , one port over 
            // http and the other over https


            // After the new project is created , we will find some folders in the solution : 
            // 1 - Connected Services : (Will be discussed later)
            // 2 - Dependencies -> Frameworks : We will find ASP.NET Core (contains Base Class Libraries for our web development) , and
            //                                 .NET Core (contains Base Class Libraries for the console application "Kestrel") 
            // 3 - Properties folder : Contains "launchSettings.json" , that contains the settings for launching the application on the Visual Studio 
            //                         Note : We have another files when deployment ... Inside this json file : 
            //         
            //       iisSettings : contains the IIS Express 2 URLs        
            // 
            //       Profiles : 
            //           - IIS Express : We discussed before ,  
            //           - Project_Structure : It's the Kestrel ! (Note : We can change it's name , and the updated name will be shown when "Run with debug")
            //		For each profile we have 2 URLs , one over http and one for https (as we marked the checkbox when making the project ...) , so now we 
            //      have 4 URLs
            // 
            // 4 - appsettings.json : Contains the settings of the application for each environment (QC env , development env , staging env , production env ) ,
            //                        Note : this file is there when deployment ... so we can have more than one appsettings (number of environments we have)
            //
            //      "Logging": (Will be discussed later)
            //		
            //      "AllowedHosts": "*" ==> means that the host name of the project can be anything , if we changed it to for example "amazon.com,amazon.net" 
            //                             that means when deployment the host name that we will buy must be "amazon.com" or "amazon.net"
            //
            //      "ConnectionStrings": {
            //			"Connection01": "Server = . ; database = test1 ; trusted_connection = true"
            //       }
            //
            //
            // 5 - Program.cs : See the notes written inside the class
            // 
            // 6 - Startup.cs : See the notes written inside the class



            // The all Cycle : 
            // 1 - Application starting program class 
            // 2 - Startup class 
            // 3 - ConfigureService() for registering service    (in startup class)
            // 4 - Configure() pipeline is created               (in startup class)
            // 5 - Ready for Requests


            // Note : Take care about Json files , any error in the syntax will not appear when compilation and it will be difficult to find !!


            /* End ******************************************************************************************************************/

            #endregion


            #region Postman application

            /* Start *****************************************************************************************************************/

            // verb "Get" works with browsers , any other verb doesn't work 
            // all varbs work with Postman , because postman works with JavaScript 


            /* End ******************************************************************************************************************/

            #endregion


            #region Upgrading to .NET 8

            /* Start *****************************************************************************************************************/

            // Double click on the project , then change the "Target Framework" to .net 8 , and if there are any packages installed then also change their
            // version to the latest version of .net 8

            // We will notice that .net 8 supports the old structure (program and startup class)

            // To work with the new style : 
            // 1 - In the program class , delete the function called "CreateHostBuilder" that uses the startup class in it .. Now the program class contains
            //     only the Main Function 
            // 2 - In the Main function , make a new variable : var webApplicationBuilder = WebApplication.CreateBuilder();
            // 3 - Now use this variable to configure the services (all configurations that was in the ConfigureServices method in startup class) :
            //     webApplicationBuilder.Services.AddControllersWithViews();
            // 4 - Build tha web application : var app = webApplicationBuilder.Build();
            // 5 - Put all the middlewares here (Code of Configure function that was in startup class) :
            //
            //
            // if (app.Environment.IsDevelopment())
            // {
            // 		app.UseDeveloperExceptionPage();
            // }
            // app.UseRouting();
            // 
            // app.MapGet("/", async context =>
            // {
            // 		await context.Response.WriteAsync("Hello World!");
            // });
            // 
            // app.MapGet("/Shoura", async context =>             // a new route here , URL/Shoura ... 
            // {
            // 	await context.Response.WriteAsync("Hello Shoura!");
            // });

            /* End ******************************************************************************************************************/

            #endregion


            #region Basic structure ...

            /* Start *****************************************************************************************************************/

            // Product             
            // DbContext       
            // ProductRepository   -> contains methods Get() , GetAll() , Add() , Update() , Delete() .. here inside these methods we use object from DbContext 
            // ProductService      -> contains methods GetProductById() , GetAllProducts() , ... here inside these methods we use object from ProductRepository
            //                        We have additional business logic here , ex: products that are in categories starting with character 'X'
            // ProductController   -> contains the Action methods .. here inside these methods we use object from ProductService

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
