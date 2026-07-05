namespace Regions
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // When to use the Resolver in AutoMapper (Other cases than the discussed here).

            /* End ******************************************************************************************************************/

            #endregion


            #region Specification Design Pattern

            /* Start *****************************************************************************************************************/

            // Specification Design Pattern : Helps me fo build the Query by a dynamic way .. leads to avoiding many problems and
            //                                decreasing the code we write

            // The LINQ Query consists from 2 parts : 
            // 1 - The sequence that we will perform the query on (local or remote) 
            // 2 - LINQ Query itself "Specifications" (LINQ operators , ex: include , where , order , ... )

            // So we want to have a function that builds the query
            // The function takes : 
            // 1 - Sequence or DbSet that we will work against it (Type IQueryable<T>)
            // 2 - Specification object (having property for each and every specification)

            // Note : The query will be returned working with differed execution , we will note use element, casting, aggregate operators
            //        inside the function

            // Today when implementing the specification design pattern , we will work with 2 specifications only (Where and Include)

            // Start : 
            // in the "Core" project make a new folder "Specifications" that will contain the interface and the implementation of it , but
            // why the implementation ? because this implementation WILL NOT CHANGE if we have more than a repository layer , so it's better
            // to be inside the repository layer
            // BUT
            // The STATIC class "SpecificationsEvaluator" That will contain the function that will take 2 parameters 
            // (DbSet,ISpecification object) will be in the repository layer , because the way it works may change over different 
            // database providers (working with SQL is different from working with NoSQL) so this will be in the repository layer 
            // (we can have more than one repository layer with different databases)


            // Now we must make a class for specifications for each entity that inherits from BaseSpecifications and Specifies the type of T
            // ex: for product see class (in core project folder "Specifications") => ProductWithBrandAndCategorySpecifications
            // Now see the class "Product"

            /* End ******************************************************************************************************************/

            #endregion


            #region Product DTO and Automapper Package

            /* Start *****************************************************************************************************************/

            // We will notice that the return of the API has nesting object .. ex: Product has brand which is an object having Id and name
            // we don't want this nesting , so what ? use a DTO => Data Transfer Object 

            // So we will make a folder in the API Project called "DTOs" , and add "ProductToReturnDTO" .. and then install the Automapper
            // package in the API project (The project that we will map between different object types) , and also make the mapping profile 
            // in the API project and adding this profile in the services 

            /* End ******************************************************************************************************************/

            #endregion


            #region Prcture URL (Automapper Resolver and Static files)

            /* Start *****************************************************************************************************************/

            // Sometimes we need to map in an advanced or complex way, ex: we want to get the BaseURL from the appsettings and concat it 
            // with the image URL from the database table  , how ? this couldn't be done in the MappingProfile class (we cannot ask the CLR in
            // the ctor to provide an object from IConfiguration , This can be done only by Explicit asking that we discussed last session)
            // So we can make a class "ProductPictureUrlResolver" in the same folder of the MappingProfile class 


            // Now we must "UseStaticFiles" middleware to make the kestrel able to serve requests for static files (same as we did in MVC)
            // and make "wwwroot" folder and put the images inside it

            /* End ******************************************************************************************************************/

            #endregion


            #region Error Types

            /* Start *****************************************************************************************************************/

            // When consuming the end point , we could have errors , and these erroes have different structures and maybe unwanted 
            // details ... so we must make the any type of errors have a standard shape and structure to be easily handled by the 
            // consumers .. 

            // Error Types : 
            // 1 - Not Found
            // 2 - Server Error (throw exception)
            // 3 - Bad Request
            // 4 - Bad Request (Validation Error) (ex: the id is int but we provide it as a string in the URL)

            /* End ******************************************************************************************************************/

            #endregion


            #region Handling response of "NotFound" , "BadRequest" , "Unauthorized" 

            /* Start *****************************************************************************************************************/

            // First we will handle the response of "NotFound => 404" , "BadRequest => 400" , "Unauthorized => 401" 
            // and they will return the same error response with the same structure 
            // Notice that when returning NotFound() , BadRequest() , Unauthorized() we have another overload that takes the object we
            // want to return , so we will make a class that will represent the returned error ... In APIs project , make folder "Errors" ,
            // that contains class "ApiResponse" that contain two proeprties "Message","StatusCode" ... this will be used for example : 
            // if(product == null)
            //     return NotFound(new ApiResponse(404));       // see class ApiResponse

            /* End ******************************************************************************************************************/

            #endregion


            #region Handling response of "Validation Error"

            /* Start *****************************************************************************************************************/

            // in validation errors (Type of Bad Requests) , (ex: the id is int but we provide it as a string in the URL)
            // The error response is provided by "InvalidModelStateResponseFactory" , so we will change the object that is 
            // returned and will be of type "ApiValidationErrorResponse" that inherits from class "ApiResponse" (added property
            // "Validation Errors") 
            // Note : it's a collection of Key Value Pairs , we will make it as Array of Strings in our class 

            // Where we will configure this ? 
            // In the Program class ... see the program class in the Configure Services Region

            /* End ******************************************************************************************************************/

            #endregion


            #region Handling response of "Server Error"

            /* Start *****************************************************************************************************************/

            // if a server error occured we will notice that the "DeveloperExceptionPage" is shown ... how ? 
            // starting from .Net 6.0 , the developer page is shown even we did't call this middleware in the program class by :
            // app.UseDeveloperExceptionPage();

            // We will make a middleware that will be the first middleware when the request comes , and the last middleware the response 
            // will go through , Now we will discuss how to make a middleware "By Convention" 

            // Start with making a middleware folder in the API project , add a class inside it called "ExceptionMiddleware" 
            // and in the program file , when configuring the middleware => app.UseMiddleware<ExceptionMiddleware>();
            // Note : The name of the class must end with "Middleware" and also the class must contain a method like this :
            // public async Task InvokeAsync(HttpContext httpContext) { ... }
            // See the ExceptionMiddleware class ... 

            /* End ******************************************************************************************************************/

            #endregion


            #region The three ways for Creating a Middleware

            /* Start *****************************************************************************************************************/

            // Convention Based : 
            // Class name Ends with "Middleware" , ex: ExceptionMiddleware
            // having a function takes one parameter type HttpContext : public async Task InvokeAsync(HttpContext httpContext) { try catch }
            // Note : In the ctor we will have a parameter "RequestDelegate next" ... 

            // Factory Based : 
            // Implement the interface called "IMiddleware" and implement the interface => will implement a function : 
            // public async Task InvokeAsync(HttpContext httpContext , RequestDelegate next) { try catch }
            // Leads to the same result of the last "Convention Based"

            // Request Delegate :
            // Write the middleware in the program file : 
            // app.Use(async (httpContext , _next) => { try catch })              // Third Overload

            /* End ******************************************************************************************************************/

            #endregion


            #region Handling response of "Not Found" Endpoint

            /* Start *****************************************************************************************************************/

            // This is different than the Not Found that we discussed before , this is NotFound Endpoint
            // Ex: BaseUrl/hamada
            // We actually don't have an end point like this so the response is empty ... we will solve this problem now and return a
            // response with "Message" and "StatusCode" 

            // To change Edit the default response ... go to program class and in the Configure Middlewares : 

            /* End ******************************************************************************************************************/

            #endregion


            #region Swagger Improvement

            /* Start *****************************************************************************************************************/

            // Ignore this controller , don't document it in Swagger 
            // Above the controller : [ApiExplorerSettings(IgnoreApi = true)]


            // Improve Documentation : 
            // Above the controller : [ProducesResponseType(typeof(ProductToReturnDTO),StatusCodes.Status200OK)]
            // Above the controller : [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)] 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
