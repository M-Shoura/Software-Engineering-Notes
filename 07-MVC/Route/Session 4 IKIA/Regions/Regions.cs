using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegionsProject
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // "Modal" in bootstrap
            // See folder named with "[Notes] Repository Design Pattern" in the videos folder (some pictures ..)

            /* End ******************************************************************************************************************/

            #endregion


            #region Start making Repositories in DAL

            /* Start *****************************************************************************************************************/

            // Now we will start making the Repositories (They are in the Data Access Layer [DAL] inside the Presistence folder) , 
            // Presistence because this data is presistent and will live long time in the database .. there are other types of data
            // that are Temporary stored in the database

            // We will have a Repository for every table in the database (or from the next session we will work with Generic Repository ,
            // but now it's not important because we have only one entity "Department") 

            // First we will generate an Interface "IDepartmentRepository" that will contain the method signatures (we develop against
            // interfaces , notice the photoes provided by the instructor) .. so we use the interface because : 
            // 1 - sending any object from a class that implement the interface
            // 2 - Easy mocking and testing 

            // Any Repository will have some methods (about 5 methods) , they can be more but now we will start with 5 methods : 
            // 1 - GetAll
            // 2 - Get
            // 3 - Add
            // 4 - Update
            // 5 - Delete

            // After the interface we will create a class called "DepartmentRepository" in the "Departments" folder and the class will
            // implement the interface

            // Here in the class we will use the "Dependency Injection" , how ? 
            // Any method in the class is an object member method so if we want to use it we must have an object from the class ...
            // so we will ask the CLR to provide us the object when we want (adding the service in the program class) ... also inside
            // this class we want to use an object from "ApplicationDbContext" so we will ask the CLR to provide us with this object
            // when we want to use it inside the previous 5 methods mentioned 

            // We attach this tasks to the CLR because it's difficult to add all these dependencies and objects + we cannot specify
            // the lifetime of the object that we created

            // We can request an object from the CLR for a service that we registered in the Dependency Injection container by 5 ways : 
            //
            // 1 - In the Constructor (object accessable within the whole class)
            //       ex: private readonly ApplicationDbcontext _dbcontext; 
            //           public DepartmentRepository(ApplicationDbcontext dbcontext) { _dbcontext = dbcontext; }
            //
            // 2 - In a method parameters (object accessable within the method only)
            //       ex:  public Department? GetById(int id , [FromServices] ApplicationDbcontext dbcontext) {...}
            //
            //
            // 3 - Creating object from the Dependency Injection Container and get a wanted service from this container 
            //       Note : (will be discussed later .... )
            //       ex: using var scope = serviceProvider.CreateScope();
            //           var departmentRepository = scope.ServiceProvider.GetService<IDepartmentRepository>();
            // 
            // 4 - ..... (used in Views only [Razor Page])
            // 5 - ..... (used in Controllers only)


            // After finishing the repository , we notice that we used SaveChanges many times 
            // after adding -> SaveChanges();
            // after updating -> SaveChanges();
            // after deleting -> SaveChanges();
            // we are using SaveChanges(); in a bad way , we must use it only one time after many updates , deleted and adding .... 
            // So we must solve this problem by using the "UnitOfWork" design pattern (discussed next session)

            // Don't forget to register the service in the program in the ServiceCollection

            /* End ******************************************************************************************************************/

            #endregion


            #region Find EFCore method  

            /* Start *****************************************************************************************************************/

            // if the data is found in the local memory then retrieve it , else retrieve it from the database

            // var department = _dbcontext.Departments.Local.FirstOrDefault(d => d.Id == id);
            // if(department == null)
            //     department = _dbcontext.Departments.FirstOrDefault(d => d.Id == id);

            // Or use the Find method !! does all the above code , checks in the local first if not found retrieves from the Database
            // and Takes the PK of the table to search with 

            // Note : Find method takes (params array of object) ex: in the many to many entity we have composite PK so (StdId , CrsId)

            // var department = _dbcontext.Departments.Find(id);
            // var department = _dbcontext.Find<Departments>(id);        // Efcore 3.1 

            // Important , What if the data is changed and find still finds locally first ?
            // GPT :
            // - If the Data is Updated Locally in the DbContext:
            //   When the Find method is called again for the same entity, it retrieves the locally tracked version of the entity
            //   from the DbContext. Updated data will be retrieved if the entity was modified locally within the same DbContext
            //   instance(because EF tracks changes).
            //
            // - If the Data is Updated in the Database (Externally, Data is updated directly in the database by another process or tool) : 
            //   The Find method does not query the database again if the entity is already being tracked by the DbContext. It will
            //   return the tracked version (which does not reflect external changes). To get the updated data from the database,
            //   you need to reload the entity explicitly.
            // 
            // - How to Force a Database Query to Get Updated Data ?
            //   1 - Use Entry.Reload();
            //       ex: context.Entry(entity).Reload();
            //
            //   2 - Detach the Entity : Detach the locally tracked entity and then call Find again to re-query the database
            //       ex : context.Entry(entity).State = EntityState.Detached;


            /* End ******************************************************************************************************************/

            #endregion


            #region Start Making Services in BLL

            /* Start *****************************************************************************************************************/

            // inside the folder "Services" , add a folder "Departments" that will contain any classes or interfaces for Department
            // module 
            //
            // inside the service , we will put the business we need ... Also we will use DTOs 
            //
            // What is DTO ?
            // Data Transfer Object (it's a class , but better to be "Records" [discussed later C# 9.0 feature]) . object responsible for
            // data carrying between two layers (or between frontend and backend in APIs). if we want to return some of the properties
            // inside an entity , DTO for GetAll may be not the same DTO for Create maybe not the same DTO for GetById

            // So inside the BLL project we will make a new folder "Models" or "DTOs" or "CustomModels" ... I will use "DTOs" , and
            // one model can have more than one DTO (one for create , one for GetAll , ... ) so we will make a new folder for 
            // departments inside the DTOs folder to contain all the DTOs for module department

            // after finishing the Interfaces , inside the "Departments" folder in the BLL layer , create a new class "DepartmentService"
            // that will implement the interface 

            // Note : to go to the interface -> F12
            //        to go to the implementation of the interface in a class -> Ctrl+F12

            // Don't forget to register the service in the program in the ServiceCollection


            // notice the "DepartmentService" and "IDepartmentService" and see the implementation

            /* End ******************************************************************************************************************/

            #endregion


            #region Start making Controllers in the PL

            /* Start *****************************************************************************************************************/

            // inside the Presentation Layer (MVC project) , and inside the Controllers folder , create a new "Empty MVC controller"
            // called "DepartmentController"

            // Relationships that the controller is in : 
            // 1 - inheritance : DepartmentController is a Controller 
            // 2 - Association Composition : DepartmentController has a IDepartmentService 

            // Don't forget to register the service in the program in the ServiceCollection

            // Note : For every action in the controller , we must specify a verb .. because if we didn't specify the action will work 
            //        with any verb 

            // right click on the action -> Go to view .. if error then right click -> Add view -> Razor View -> Empty without model 

            // First thing we do in the view : Specifying the data type that we are working with (that the view will get , or that the
            // view will send "create , update , delete" -> Post) 
            // @model IEnumerable<DepartmentToReturnDTO>    ex: in the Index 
            // @model CreatedDepartmentDTO                  ex: in the Create

            // See the view for "Index" , important comments 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
