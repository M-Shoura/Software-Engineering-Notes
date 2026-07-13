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

            // toast in Bootstrap
            // difference between IQueryable and IEnumerable and their extension methods
            // Difference between DTOs and ViewModels and when to use them ?

            /* End ******************************************************************************************************************/

            #endregion


            #region Continue implementing actions in Employee Module

            /* Start *****************************************************************************************************************/

            // View model : class that represents the data that will be rendered in the view 
            // view model and DTO have the same concepts
            // DTO => carrying the data between layers 
            // view => carrying the data that will be rendered in the view (without having more data)
            // With viewmodels or DTOs we use mapping , manual or using a package .. or overriding the casting operators (discussed before)

            // so inside the View Models folder (or Models folder in the PL layer) .. create a new folder "Departments" that will have 
            // all the view models of the department module .... inside this folder , create a new class "DepartmentEditViewModel"


            // When implementing the delete , we can use a Modal or use the same way with details but with some changes ... 

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with Employee module

            /* Start *****************************************************************************************************************/

            // first of all , we added a folder called "Common" inside the DAL layer , that will have another folder "Enums" .. 
            // and added the two enums "Gender" and "EmployeeType" inside this folder 

            // Note : we want to save the Enum as a string in the database, ex: "Male" or "Female" stored in the database not "1" or "2"
            //        and when retrieved it's retrieved as a gender value "1" or "2"
            //        so this is done in the configuration class as shown : 
            //
            //                      builder.Property(e => e.Gender)
            //                          .HasConversion
            //                          (
            //                              (gender) => gender.ToString(),                               // saved in the DB
            //                              (gender) => (Gender)Enum.Parse(typeof(Gender), gender)      // When retrieving from DB
            //                          );


            // When making the repositories we notice that we have the same functions in the interfaces , and also the same implementation
            // in the classes (with changing the types only ..) so we must use a Generic Repository 
            // We added a folder "_Generic" (starts with _ to be the first folder in the "Repositories" folder [On Top]) and added inside
            // it the interface "IGenericRepository" and class "GenericRepository"

            // Note : When inheriting from class "GenericRepository" and implementing "IGenericRepository" , we will have an error,
            //        that's because the parameterless ctor created by the compiler in the child by default chains on the parameterless
            //        ctor in the parent ... and in out case the parent "GenericRepository" doesn't have a parameterless ctor 
            //        so we must make a ctor that chains on the parent ctor (that chains on the only one ctor that takes an object from
            //        the DbContext class) .. so we ask the CLR to provide an object from the DbContext in the Department and Employee
            //        Repositories not in the GenericRepository

            // Note : Don't forget to make the dbcontext field in the generic class as a "private protected" to be inherited to the
            //        child classes , incase we want to have a specific method for an entity so the private protected field will be 
            //        inherited in that entity (ex: we have a specific method for Employee that will use the dbContext ... )


            // When implementing the Employee Service , we will notice that the 2 businesses are the same so we should use a Generic service
            // THIS IS WRONG !! only in this case it appears that the services are the same but this is not right in an actual business
            // so we cannot make this generic (Note : we can make a generic service for the common methods (helper methods) , not the actual
            // services)

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
