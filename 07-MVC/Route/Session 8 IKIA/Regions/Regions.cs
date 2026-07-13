using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegionsProject
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // IEquatable interface
            // browser storage types
            // Relative vs Absolute Paths
            // TimeSpan class 
            // Add Authentication Service in dot net

            // don't miss to add "MultipleActiveResultSets=True" in the connection string to allow multiple queries to execute on the
            // same database connection

            /* End ******************************************************************************************************************/

            #endregion


            #region Security Module Overview

            /* Start *****************************************************************************************************************/

            // Security -> Authentication and Authorization 

            // Step 0 : Identification (Registeration) having an account in the app


            // Step 1 -> Authentication : Who are you ? if i can use this application or not
            //                            (Login -> have a username and password to identify you)
            //                            Where you come from ? 
            //                               - Local (Registered inside our app) 
            //                               - External Server (External login using Google , Facebook , ...)
            //                               - Active Directory (any login to the web app must login in the server first)
            //                               - Federated Server (Souq -> Amazon)

            // Step 2 -> Authorization  : What can you do ? (Ex: Roles of an admin differs from Roles of a regular user)
            //                            Relationship between the user and the Role is Many to Many (in most examples)
            //                            (Ex: a person can be a delivery , and a customer in Talabat App ... )

            // Note : If we don't have Roles , then the Authentication is the same as Authorization 


            // Instead of implementing the security module from scratch , we use the "Identity" Microsoft Package

            // We have 3 Main services inside the Identity Package : 

            // 1 - User Manager (Identity User) -> identification (Registeration)
            //          1 - Create User (Sign Up)
            //          2 - Update USer
            //          3 - Delete User
            //          4 - Read User Data
            //          5 - Confirm Account

            // 2 - Sign In Manager (Identity User) -> Authentication
            //          1 - Sign In
            //          2 - Sign Out
            //          3 - IsSigned
            //          4 - Reset Password
            //          5 - Two Factor Authentication
            //          6 - OTP Authentication
            //          7 - External Login (Facebook , Google)

            // 3 - Role Manager (Identity Role) -> Authorization
            //          1 - Create Role
            //          1 - Update Role
            //          1 - Delete Role


            // Also we have minor services , ex: Hash Password to be stored in the database

            /* End ******************************************************************************************************************/

            #endregion


            #region Start using the Identity Package

            /* Start *****************************************************************************************************************/

            // install the package : Microsoft.AspNetCore.Identity.EntityFrameworkCore

            // First we have entities that comes with the package , incase we want to customize and add our properties then we inherit 
            // from the entity provided by the package and then add our properties .... (ex: we have IdentityUser , but doesn't contain
            // FirstName and LastName !! so we will make our entity "ApplicationUser" and will inherit from the "IdentityUser" then add
            // our properties inside this ApplicationUser class , and then use this class instead of the default used "IdentityUser")
            // .... So inside the DAL , inside folder "Entities" , we will make a folder "Identity" to contain the type we want to use 
            // instead of IdentityUser ==> "ApplicationUser"
            //
            // Ex: DAL -> Models -> Identity -> ApplicationUser 


            // inside the security module , we have 7 models : 
            // 1 - IdentityUsers => For Users
            // 2 - IdentityRole  => For Roles
            // 3 - UserRoles     => ManyToMany Relationship between the user and roles
            // 4 , 5 , 6 , 7 - Will be discussed now

            // so we must add a DbSet for each and every model ???? No , but instead of inheriting from the DbContext inside the 
            // ApplicationDbContext class , we will inherit from the IdentityDbContext class that have the 7 DbContexts and also
            // inherits from class DbContext 

            /* End ******************************************************************************************************************/

            #endregion


            #region Identity User Class

            /* Start *****************************************************************************************************************/

            // The identity user class have 2 versions , a non-generic one and a generic one , the non-generic inherits from the generic
            // one , that sets the PK as a string ... so if the PK is a string then use the non-generic one , else use the generic version
            // with specifying the type of the PK

            // in the non-generic version , we have 2 constructors , one parameterless that initializes the Id with a new GUID and 
            // also initializes the Security stamp with a new GUID (Security stamp : discussed later) .. and the other constructor 
            // takes a parameter "string username" and chains on the first one , with setting the Username ... 

            // We willl notice that inside the Identity user class that there are property for "UserName" and "NormalizedUserName"
            // The normalized is the User Name but capitalized , and used for searching 

            /* End ******************************************************************************************************************/

            #endregion


            #region Identity DbContext class

            /* Start *****************************************************************************************************************/

            // Now the "ApplicationDbContext" inherits from "IdentityDbContext"

            // We have 2 versions from IdentityDbContext class , a non-generic version and a generic versions with 3 Overloads 

            // 1 - The non-generic (Only one) :
            // public class IdentityDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
            //     - inherits from the second overload
            //     - uses the IdentityUser as a base class for Users
            //     - uses the IdentityRole as a base class for Roles
            //     - Specifies the PK type of the classes to be string 

            // 2 - The first generic : 
            // public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string> where TUser : IdentityUser
            //     - inherits from the second overload
            //     - YOU Will specify the model , not the default IdentityUser (ex: ApplicationUser that inherits from IdentityUser)
            //     - uses the IdentityRole as a base class for Roles
            //     - Specifies the PK type of the classes to be string 
            //       Note: The Pk is set to type string , so if we want to use this overload the PK of the TUser that we made must be
            //             string also .. if the PK is not string in the and we inherited from "IdentityUser<int>" for example then the
            //             PK must be int , then we will use the second generic overload and set the type of the PK
            //
            //             ex: class ApplicationUser : IdentityUser<int> (all properties but with FName and LName also + PK is int)
            //                 class ApplicationRole : IdentityRole<int> (all properties but with XYZ also + PK is int)
            //                 public class ApplicationDbcontext : IdentityDbContext<ApplicationUser,ApplicationRole,int>   


            // 3 - The second generic : 
            // public class IdentityDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey, IdentityUserClaim<TKey>,
            //                                                                         IdentityUserRole<TKey>, IdentityUserLogin<TKey>,
            //                                                                         IdentityRoleClaim<TKey>, IdentityUserToken<TKey>>
            //                                                                         where TUser : IdentityUser<TKey> where TRole :
            //                                                                         IdentityRole<TKey> where TKey : IEquatable<TKey>
            //     - inherits from the third overload , that 



            // The Full Hierarchy is : 
            // IdentityDbContext (last generic overload) inherits from IdentityUserContext  
            // IdentityUserContext (last generic overload) inherits from DbContext (We used all previous sessions) 

            // we can use the default IdentityUser with PK => string or use the IdentityUser<TKey> with Pk => TKey
            // we can use the default IdentityUser or make "ApplicationUser" that inherits from "IdentityUser"
            // Then we will know what to use from "IdentityDbContext"

            /* End ******************************************************************************************************************/

            #endregion


            #region Adding migration to add the 7 tables

            /* Start *****************************************************************************************************************/

            // When adding a migration , we will notice that there is an error : "The Entity Type X requires a Primary Key" , where X is
            // one of the 7 tables we will add 

            // Now the Fluent APIs configurations must be called ! they are in the "OnModelCreating" function of the base , the base here
            // is the "IdentityDbContext" (Note : the "OnModelCreating" in IdentityDbContext is not empty as it was in the DbContext class) 


            // DAL Layer Finished :
            // Now it's not important to make repositories for each and every model ... because we have "Stores" , and we will NOT Work 
            // with the "UnitOfWork" design pattern

            // BLL Layer Finished : 
            // No Work to do ! we have 3 main services that are already implemented 
            // 1 - User Manager
            // 2 - Sign In Manager
            // 3 - Role Manager

            // PL Layer : start now

            /* End ******************************************************************************************************************/

            #endregion


            #region Start implementing in the Presentation Layer

            /* Start *****************************************************************************************************************/

            // First Add the Account Controller or Auth Controller in the "Controllers" folder in the PL layer

            // now we will start implementing Sign Up , Sign In , Sign Out
            // or (Work With any naming)     Register ,  Login  , Logout


            // We will use a templete from the internet , link : https://codepen.io/colorlib/pen/aaaoVJ

            // Add a new Layout "_AuthLayout" in the "Shared" folder , and in this folder copy the templete HTML Code to it ... then
            // add the CSS code in a new css file inside the wwwroot -> css , and edit the css file path in the HTML layout file


            // in the signup , we will work with a model of type "SignUpViewModel" , so create and add it inside the "ViewModels" folder

            // After sign in , if we want to see the token , then in the browser : 
            // inspect -> Application -> Cookies -> AspNetCore.Identity.Application   (Default Token)

            // Note : We generate the token by the default configurations of the dot net , in APIs we will use the JWT package

            /* End ******************************************************************************************************************/

            #endregion


            #region Using Authentication in Controllers

            /* Start *****************************************************************************************************************/

            // before the user can use any action in the controller , he must be authenticated and having a token

            // First , in the program class we must add the two middlewared for security : 
            // 1 - app.UseAuthentication();
            // 2 - app.UseAuthorization();


            // The default of any controller , that it has a Data Annotation Filter [AllowAnonymous] , we will change it to 
            // [Authorize] data annotation (it have three parameters ) -> Any user that wants to use this controller must be authorized
            // ex: see the Home controller

            // if we deleted the token from the Cookies (if a token exists) , we then cannot use the home controller unless we Signin 
            // and have a valid token ... if we want to use the action and we don't have a token then we will be redirected to 
            // another URL , it's by default "/Account/Login" ..... so what can we do to change this defaults ???

            // in the program , configure the service "ConfigureApplicationCookie" , see the program file


            // The [Authorize] filter data annotation can take 3 Parameters 
            // 1 - AuthenticationSchema (default = Identity.Application)
            // 2 - Policy (discussed later)
            // 3 - Roles  (discussed later)

            // ex: [Authorize(Roles = "Admin")]                 Authorized and have Admin Role 

            // ex: [Authorize(Roles = "Admin, Customer")]       Authorized and have Admin Role OR Customer Role

            // ex: [Authorize(Roles = "Admin")]                 Authorized and have Admin Role AND Customer Role
            //     [Authorize(Roles = "Customer")]            



            // Implementing the Sign out : 
            // we basically Remove the Token from the browser cookie

            /* End ******************************************************************************************************************/

            #endregion


            #region Forget Password and Send Reset Password Email

            /* Start *****************************************************************************************************************/

            // < p >< a asp - action = "ForgetPassword" > Forget Your Password ?</ a ></ p >
            // When clicking on this , it will execute the Action named "ForgetPassword" with GET verb because from the web browser
            // we can only execute actions with "GET" verbs 

            // Note : In the ForgetPasswordViewModel , we have only one property of type email , we could use @model in the view is of
            //        type string instead of using a specific veiw model but this is better incase we want to put any validations in 
            //        the property ... this is better than validating on this string in the Action in the controller ...


            // After making the forget password , we then must send Email to the user that forgot his password 
            // We will make an Email service ... same as the Attachment Service , see BLL -> Common -> Services -> Emails


            // Note : To read data from the App Settings , then we ask the CLR for providing an object from IConfiguration ...

            /* End ******************************************************************************************************************/

            #endregion


            #region Update from any version to any other version

            /* Start *****************************************************************************************************************/

            // double click on the project , change the target framework to the version you want , then change the version of all 
            // packages , (be carefull with versions ... ) , or use the NuGet packages UI

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
