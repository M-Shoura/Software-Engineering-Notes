using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection;
using System.Reflection.Metadata;
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

            // How to use AJAX Request and implementing it with Search Functionality ?
            // ReadOnly Vs Frozen Vs Immutable
            // FileMode enum , and working with files 
            // more search about enctype in the HTML Form 
            // More about Asynchronous code 
            // we will not use Asynchronous code with Update or Delete functions (Self study)
            // when to use AddAsync ? because in some cases it will cause headache on the program !!
            // using .Result with Asynchronous code .. 

            /* End ******************************************************************************************************************/

            #endregion


            #region Implementing Search Functionality in Employee Index View

            /* Start *****************************************************************************************************************/

            // See the index view , we added a form for searching and added a parameter in the index action in the employee controller
            // The value that we will use in searching (name)

            /* End ******************************************************************************************************************/

            #endregion


            #region Mapping using AutoMapper

            /* Start *****************************************************************************************************************/

            // We will use auto mapper when :
            // 1 - The same mapping is done multiple times 
            // 2 - Complex mapping

            // There are many packages for Auto mapping , we will use "AutoMapper" package which is a third-party package 
            // 1 - install the package inside the PL Layer
            // 2 - inject in the constructor object from IMapper and create and assign a private field to be able to use it in the controller
            // 3 - Adding Profiles (how to map from one type to another .. ) -> Add folder inside PL layer "Mapping" , containing one class
            //     for all modules or more than one class , we will add one class "MappingProfile" thet inherits from class "Profile" and
            //     in the Ctor implement the way of mapping between types and each other
            // 4 - Allow dependency injection for IMapper in the program class  


            // implement it whenever we want ... (ex: used in department controller) , see also "MappingProfile" class 

            /* End ******************************************************************************************************************/

            #endregion


            #region Unit of Work Design Pattern

            /* Start *****************************************************************************************************************/

            // Service -> interact with the Repositories directly                                      xxx OLD WAY
            // Service -> interact with the Unit of work , unti of work interacts with the Repos         New Way

            // Why to use the Unit Of Work ? 
            // 1 - In the repository , in Add , Update , Delete ... in each of them we "SaveChanges()" , this is not a good thing (ex: if
            // we add and update and delete in the Create Action then "SaveChanges" will be executed three times !! ) and this makes the 
            // SaveChanges useless (it's used when many changes occurred then save changes only one time)
            //
            // 2 - Unit Of Work class now will interact with the database through the DbContext
            // DbContext has a DbSet for every model , the unit of work has a property for each and every repository
            // DbContext has "SaveChanges" , the unit of work has "Complete [Does save changes but only one time]"
            // DbContext has Dispose , the unit of work has Dispose (for closing the connection with the database)


            // Starting implementing : 
            // in the DAL , in the "Presistence" folder , add a folder "UnitOfWork" , add inside in an interface "IUnitOfWork" (which will
            // contain signatures for properties of repositories) (Why using interface ? because we develop against interface not a concrete
            // class , so if we have another DbContext we will still use the one interface) ... also add a class "UnitOfWork" that will 
            // implement the interface "IUnitOfWork" , and will have automatic properties (having backing fields) (don't mix between
            // signatures of properties in interface and automatic properties in classes)

            // now go to the Generic Repository and delete any "SaveChanges" inside the Add , Update , Delete .. this will be done through
            // the UnitOfWork + also make them with return type "void"

            // now go to the services and the service will use an object of UnitOfWork class , not any repository

            // now add the service of Unit of work and delete the services for Repositories from Program class

            // now add the Dispose method in the Unit of Work Class , must implement the IDisposable interface (implement it inside the class
            // "UnitOfWork" or the interface "IUnitOfWork" .. no problem) . This method will dispose the connection after finishing the 
            // request , (Note : to be able to work we must implement the IDisposable interface ) . So in all the previous sessions ,
            // the connection of the dbContext was not disposed , that's because we ask the CLR to give us an object from the DbContext
            // and then we didn't use "dbContext.Dispose()"


            // Note : In APIs , we will know the best implementation for the Unit of Work Design pattern


            /* End ******************************************************************************************************************/

            #endregion


            #region Attachment / Document Service

            /* Start *****************************************************************************************************************/

            // Attachment Service or the Document Service -> used to work with Documents or files or any attachments in the project
            //                                               uploading , deleting , downloading , ... 

            // Storing the Attachments in the database (will be stored as Zeroes and Ones ) is a bad way (time consuming and headache on the
            // server and when retrieving we must convert from zeroes and ones to it's type) ... So the way we use is storing the files 
            // and attachments in a place (our server , google drive , share point) in this approach files are not stored in the database 
            // but their path is stored in the database as a string 

            // Attachment Services , Email Services , notification services , SMS services are third party services (integration with another
            // services maybe) , in Onion Archietecture these services are in the Infrastrccture layer , here in Three-Tier Architectire 
            // we will put these services in the BLL layer

            // In the BLL Layer , we will add a folder "Common" , then add inside it a folder "Services" , then add inside it a folder 
            // "Attachments" .. inside this folder add "IAttachmentService" , and a class "AttachmentService" 
            // Note : this can be implemented as a Static class having static functions "Update" and "Delete" rather than the last discussed

            // in the wwwroot , add a folder "files" , that will contain the attachments , so add inside it a folder "images" that will 
            // contain the uploaded images


            // add the property "string? image" in Employee model -> path of the image, 
            // add the property "" in the createEmployeeDTO -> the image got from the HTML Form
            // use the Attachment Service in the Employee service class
            // allow the Depenedency injection for the AttachmentService
            // add the enctype="multipart/form-data" in the form tag in the HTML Code

            /* End ******************************************************************************************************************/

            #endregion


            #region Asynchronous code

            /* Start *****************************************************************************************************************/

            // Synchronous : function A , function B , function C
            // function B will not be executed unless function A is executed, function C will not be executed unless function B is executed

            // Asynchronous : function A , function B , function C
            // function A and function B and function C can be executed in the same time if they don't depend on each others .. 

            // Then Asynchronous code saves more time !!


            // We will refactor all the code we written in the last sessions to work with Async 
            // using async keyword 
            // using await keyword 
            // using Task keyword (generic class [for any return type] and non-generic class [for void])
            // using Async versions of functions ex : ToListAsync();

            // await keyword is very important , it notifies us when the code is finished .. so if we didn't write await then we will 
            // not be notified then the task is finished and this will cause many problems 

            // By Convention , we change the name of the functions that uses Asynchronous code to "FunctionNameAsync" (maybe with only
            // functions that have two versions Async and Sync ... )

            // Note : we will not use Asynchronous code with Update or Delete functions (Self study)
            //        when to use AddAsync ? because in some cases it will cause headache on the program !!

            // Note : In UnitOfWork , we will use the IAsyncDisposable instead of IDisposable , and in Complete function we will use 
            //        dbContext.SaveChangesAsync(); 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
