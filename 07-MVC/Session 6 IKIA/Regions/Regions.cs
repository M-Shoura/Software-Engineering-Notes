using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegionsProject
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // IgnoreSection and IgnoreBody in views
            // When to use ViewBag and when to use ViewData ?
            // ViewBad vs ViewData vs TempData : https://www.c-sharpcorner.com/blogs/viewdata-vs-viewbag-vs-tempdata-in-mvc1
            // How to use the TempData to send the data for more than two consecutive requests ?

            /* End ******************************************************************************************************************/

            #endregion


            #region Difference Between IEnumerable and IQueryable 

            /* Start *****************************************************************************************************************/

            // Note : This is not related to MVC , it's related to Linq and EfCore ...

            // If the Return was IEnumerable , we will load all the data , and then any "query" , "filter(where)" ,
            // "Aggregation Function" , "Element Operator" all of them will be executed in the Application.
            // ex: Select * from Employees , and in the application will execute the filters , aggregation Function , ....

            // If the Return was IQueryable , then the "Where" operator will be mapped to "Where" in database , "FirstOrDefault" will be
            // mapped to "Top(1)" in Database , any aggregation function will be mapped to the database (rather than the Casting operators
            // because they cannot be translated to SQL , ex: ToList(); ) (when using the casting operators we use them as Extension methods
            // for the IEnumerable class "IQueryable inherits from IEnumerable")
            // ex: Select * from Employees where ......... 


            // To see the difference , make a function that returns a "IEnumerable" and another function that returns "IQueryable" and
            // then execute the two and with the SQL profiler or the Kistrel console application see the Performed Query on the DB


            // Note : Don't mix between differed executing and Immidiate execution , and the difference between "IEnumerable" ,"IQueryable"
            // Note : IEnumerable has it's extension methods , IQueryable has it's Extension methods but without the Casting operators ..

            // Important : It's better to use the immediate execution casting operators in the Service classes , ex: when using 
            //             GetAll then it must return the result as a list or ... , better than executing the query when we want to
            //             Enumerate on the sequece "separation of concerns"

            /* End ******************************************************************************************************************/

            #endregion


            #region Client Side Validation

            /* Start *****************************************************************************************************************/

            // Validations are on Two Levels : 
            // 1 - Database Level -> handled by the Fluent APIs 
            // 2 - Application Level :
            //      2.1 -> Server Side -> handled in the code it self
            //      2.2 -> Client Side -> use the two JQuery validation Plugins


            // we use the client-side validations to decrease the number of "Bad Requests" to the server ... bad requests are for example
            // when creating a department and the name is not optional , then if the user created a department without providing a name
            // then without client-side validation the request will go to the server and the server will reject creating the department
            // So why this is not done in the client-side ???


            // To apply the Client validations : 

            // when we created the project with the templete we noticed that in wwwroot folder -> lib folder -> we will notice that there 
            // are two validation packages are instllaed "jquery-validation" and "jquery-validation-unobtrusive" beside "bootstrap"

            // In our case we want to implement the client-side validation in "Create" and "Edit" in Views in Employee and Department modules
            // and if we have (sign-in / sign-up) also 

            // so go to the views and "Drag and Drop the two files for validation" , we will use the two not minified files ..
            // ex: <script src="~/lib/jquery-validation/dist/jquery.validate.js"></script>
            //     <script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"></script>
            // but using the previous way will not implement the validation , why ? because the JQuery is rendered inside the "@RenderBody()"
            // in the _Layout ... and to use it we must first render the "JQuery" then render the two validation files . we will notice that
            // in the last lines of the file "_Layout" the JQuery is rendered so we will render the two validation files after the JQuery

            // to achieve this we must put the two files in a section (not executed when "@RenderBody()" is rendered) , and we will manually
            // render this section after the JQuery rendering in the last lines of the "_Layout" file ...


            // ex: inside Create and Edit views for Employee and Department modules :
            //          @section ClientSideValidation {
            //              <script src="~/lib/jquery-validation/dist/jquery.validate.js"></script>
            //              <script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js"></script>
            //          }
            //     and inside the "_Layout" folder : 
            //          @RenderSection("ClientSideValidation", required: false)


            /* End ******************************************************************************************************************/

            #endregion


            #region Action Filters - ValidateAntiForgeryToken

            /* Start *****************************************************************************************************************/

            // [ValidateAntiForgeryToken] is a data annotation (Action Filter , this action will be executed or not !!)
            // if we inspect any form in out application , in web browser -> inspect in the create form for example , we will notice a 
            // hidden input in the form (Token) , this token is generated by the server .... this is used to avoid cross attacking and
            // validate that the department is created from our web application (not a third-party app like Postman) 

            // so without validating on this Forgery token we can create or edit a department from Postman and this may cause problems
            // later ... so it's important to put this [ValidateAntiForgeryToken] data annotation above any actions that have verb Post
            // and adds or updates something in the data in database

            // To notice the difference , try to comment that data annotation from the Create action in the department controller , 
            // and then try to add a department from Postman with providing the data in the "Body" as a "form-data" ... the department
            // will be added but if the data anntation is not commented then we cannot add the department because the Forgery token 
            // provided by Postman is not the same as the Forgery token provided by the server and is in a hidden input in the form 
            // Note : Postman Forgery token cannot be changed !! 

            /* End ******************************************************************************************************************/

            #endregion


            #region Partial View

            /* Start *****************************************************************************************************************/

            // Partial view : Part of the view that is the same in more than one view , so we will put the shared code inside a partial
            // view and render the partial view in one line without duplicating the code  

            // Ex: we will use the partial view with the 4 bottons that are in the index views (in department and employee modules)
            //     so we will add a folder "PartialViews" inside the "Shared" folder inside the "Views" folder in PL project
            //     Then add a view named with "indexBottonsPartialView" and then put the code for 4 bottons here 
            //     inside the index views , we will render the Partial view by one of the two ways : HTML or C#
            //     in HTML =>
            //     [Don't forget to send the model ... and retrieve it inside the partial view as " @model int "]
            //     - in HTML : 
            //          <partial name="PartialViews/_IndexBottonsPartialView" model="@department.Id" />
            //          <partial name="PartialViews/_IndexBottonsPartialView" model="@employee.Id" />
            //
            //     - In C# Using @Html.Partial or @await Html.PartialAsync 
            //          @await Html.PartialAsync("PartialViews/_IndexBottonsPartialView", department.Id)
            //          @await Html.PartialAsync("PartialViews/_IndexBottonsPartialView", employee.Id)


            // note also , we use client-side validation in create , update views (in department and employee modules)
            // we will notice that we have a partial view in "Shared" folder called "_ValidationScriptsPartial" , so we will put the 
            // two JQuery validation files inside this partial view and then we will render this file inside the @sections 
            // in create, update views (in department and employee modules)


            // we can use the partial view also in this case : in Create and Edit views we have the same structure , so this can be in one
            // partial view ... the DepartmentEditViewModel is the same as CreateDepartment ... so we must have the same model to use
            // the partial view , we will use the DepartmentEditViewModel for both of Create and Edit (don't forget to make changes in the
            // department controller because the create action has a parameter "CreateDepartmentDTO" and now we will change it to the
            // DepartmentEditViewModel ... )

            // this also can be done with Delete and Details , see the partial view "DetailsDeleteDepartmentPartial"

            /* End ******************************************************************************************************************/

            #endregion


            #region .cshtml comparison

            /* Start *****************************************************************************************************************/

            // View : HTML page that the server will return it as a response for a request from the end user
            //
            // Partial View : helps us to decrease the duplication of code , and put this duplicated code in one partial view and use it
            //
            // Layout : We have more than one view having the same layout (header , footer , side bar , ... ) then we will put this code
            //          in a layout and then use it View is rendered in the "Render Body" method calling in the layout (sections will not
            //          be rendered)
            //
            // Section : it's a part of the view and will not be rendered in the layout unless we render it manually by "RenderSection"
            //           method
            //
            // View Imports : we put here the namespaces that are used inside the views (same as global usings)
            //
            // View Start : we put here all the code that any view will start with (default layout) , then if we didn't specify a layout
            //              then the layout that is specified in the ViewStart will be used automatically 

            /* End ******************************************************************************************************************/

            #endregion


            #region View Storage (ViewBag and ViewData)

            /* Start *****************************************************************************************************************/

            // The view storage is a Dictionary (Key,Value) . We can access this dictionary using the ViewBag or the ViewData

            // View's Dictionary : Pass data from Controller (Action) to View (then from View to Partial View , layout , ... )
            // This is ONE DIRECTION (From Controller to View to PartialView/Layout in HttpGet , and from PartialView/Layout to View to
            // Controller in HttpPost)

            // Note : the model that we sent to the view is data , but what if we want to send Extra data ? then use the View Storage

            // ViewData and ViewBag are inherited from class "Controller" [For MVC Only] , and also their values become Null after
            // Redirection has occured , lies during the Current Request only

            // 1 - View Data : is a dictionary type property , Key & Value , Key is always a string (introduced in .Net Framework 3.5)  
            //                 ex: in controller =>    ViewData["Message"] = "Hello ViewData";
            //                     in View       =>    <div>  @ViewData["Message"]  </div>
            //                                         @ { string x = ViewData["Message"] as string; } 
            //
            //                 - so the compiler can enforece type safety (type safe), and it's better in performance
            //                   Note : it can throw an exception if it's not a string in our example here , but the compiler must 
            //                          insure that we specified a type (Casting) because it's stored as an object in the memory
            //
            //
            //
            //

            // 2 - View Bag  : is a Dynamic Type Property (introduced in .Net Framework 4.0 with the dynamic keyword) . it's the same as 
            //                 ViewData so why microsoft added it ? because ViewData Requires type conversion but the ViewBag is of type 
            //                 dynamic (and compiler will skip type safety) , it's slower (because it's dynamic)
            //                 ex: in controller =>    ViewBag.Message = "Hello ViewBag";
            //                     in View       =>    <div>  @ViewBag.Message  </div>
            //                                         @ { string x = ViewBag.Message } 
            //
            //                 - Compiler will skip the type checking at compilation time cannot enforece type safety !! worse in performance
            //                   because the CLR will try to know the type of it in the runtime
            //
            //

            /* End ******************************************************************************************************************/

            #endregion


            #region TempData

            /* Start *****************************************************************************************************************/

            // TempData is used to pass Data between two consecutive Requests .. it's a Key Value Dictionary collection , introduced
            // in .Net Framework 3.5 ... TempData uses another storage other than the storage of the view , other than the storage of
            // the ViewBad and ViewData

            // Note : we must use the casting here , as we did with the ViewData ...

            // usecase : from index view -> Create new department , if the department created then as default return to the index
            //           view with a message "Department created successfully" , shown in a Toast in the view index 
            //           and if the department is not created then show message "Department creation Falied", in the Toast

            /* End ******************************************************************************************************************/

            #endregion


            #region Employee Department Relationship

            /* Start *****************************************************************************************************************/

            // Add navigational properties and FK in the models
            // edit the DTOs and VM if wanted to be edited

            // See notes inside the create view to know how to show the departments when creating a new employee
            // and the dependency injection inside the views also 
            // Relationship 
            // asp - items can be a foreach as we wrote the static "Choose ... " , but it's easier with asp-items , and the default is null
            // but how to get the departments? we can get them inside the controller and then send them here by the view storage
            // Dependency injection inside the ctor or inside the action parameter itself by the[FromServices] data annotation beside the parameter
            // Or another way : Dependency Injection in the View or Partial View
            // Used now...    @inject IDepartmentService _departmentService and use it to get the departments


            // We must enable the lazy loading inside the DAL layer .. to load the related data (department nav property) inside Employee 
            // and enable it ".UseLazyLoadingProxies()" in the program class when adding the DbContext to the services , and also make all
            // the navigational properties as virtual 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
