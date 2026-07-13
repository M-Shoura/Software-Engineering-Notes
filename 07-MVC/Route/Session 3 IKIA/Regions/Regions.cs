using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RegionsProject
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // More about difference between Monolithic and Microservices architectures 
            // What is CRM ?
            // Video part 4 from (23-end) minutes .. (discussing some things with Chat GPT)
            // What is a sequence in database ?
            // Watch video part-8 Github [not important] 

            /* End ******************************************************************************************************************/

            #endregion


            #region N-Tiers (layers) Architecture

            /* Start *****************************************************************************************************************/

            // Now we will start the project , but before starting it we must know some details:
            // 1 - Monolithic Architecture : The project is partitioned into modules or services that are in the same project (or solution)
            // 2 - Microservices Architecture : The project is partitioned into modules or services , each one of them is in a different
            //                                  project and then they will interact with each other (each project can be implemented in a
            //                                  different technology)

            // inside the Monolithic Architecture , we can use more than one Architectural pattern (N-Tiers (layers) Architecture ,
            // Onion Architecture).. in this project we will use the N-Tiers (layers) Architecture (specifically the 3-tiers architecture)

            // Separation of concerns is achieve through multiple layers : 
            // 1 - Data Access Layer (DAL)
            // 2 - Business Logic Layer (BLL)
            // 3 - Presentation Layer (PL)

            // Data Access Layer (DAL) : Project of type "Class Library" , interacts with the database .. contains the DbContext class , 
            //                           migrations folder , Domain models , configuration classes for these models , data seeding
            //                           Also called Presistence layer because data inside this layer are presistent (NOT Temporary)

            // Business Logic Layer (BLL) : Project of type "Class Library" , has our business and we use here 2 design patterns : 
            //                              Generic Repository Design Pattern , Unit Of Work Design Pattern

            // Presentation Layer (PL) : This can be a "MVC" project , "API" project , "single page application with Blazor" project ,
            //                           "Desktop - WPF" project , "Xamrin Mobile" project .


            // Important Note Here : We can have more than one Presentation Layer , ex: if we want to make website for IKIA , and 
            //                       we want to make a dashboard of type "MVC" project and also a "API" project to serve the customer
            //                       requests .. and both projects will use the same business and the same database ... this can be
            //                       done through multiple presentation layers


            // in big systems , the 3-tiers architecture is not a good choice !

            // Before starting implementing , we must add references between the projects , to allow interaction between different 
            // layers and also sharing the installed packages (a package installed in any project can be seen through all the projects
            // having reference from each other ... )

            // Note : see video part 4 from (23-end) minutes .. (discussing some things with Chat GPT)

            /* End ******************************************************************************************************************/

            #endregion


            #region Making Projects in one solution

            /* Start *****************************************************************************************************************/

            // 1 - Presentation Layer : It's an MVC project , we will make a MVC project with the templete .. notice when making the 
            //                          project we choose .NET 8 , and there will be Authentication Type is None , authentication is
            //                          discussed in the workshops . Also we will notice that inside the wwwroot folder some libraries
            //                          are installed , one of them is the "JQuery validation" that is used for client-side validation
            //                          this is good for minimising the number of requests to the server

            // 2 - Business Logic Layer : It's a Class Library project

            // 3 - Data Access Layer : It's a Class Library project

            // Then we must add refernces between the projects : 
            // 1 - in BLL , right click on Dependencies , Add Project Reference to DAL
            // 2 - in PL ,  right click on Dependencies , Add Project Reference to BLL
            // Now any package installed in any project can be seen be by the other projects


            // - inside the BLL , add folder "Services"
            // - inside the DAL , add folder "Models"
            // - inside the DAL , add folder "Presistance" , then inside it add folder "Data" , and folder "Repositories"
            //   Note : We can folders "Data" and "Repositories" directly in the DAL project without "Presistance" folder
            // - inside the folder "Presistance" , inside the folder "Data" , add new folders "Configurations", "Migrations", "DataSeeding"

            /* End ******************************************************************************************************************/

            #endregion


            #region Department Module

            /* Start *****************************************************************************************************************/

            // we start with the Date Access layer (DAL) , inside "Models" folder add class "ModelBase" that will contain common properties
            // in all the models we have . Then in "Models" folder add folder "Department" , inside it add class "Department".
            // Class department will inherit from class "ModelBase" .. 


            // Configurations : 
            // inside the folder "Presistance" , inside the folder "Data" , inside the folder "Configurations" , add a folder Department
            // and then add a class "DepartmentConfigurations"


            // Data Seeding : 
            // inside the folder "Presistance" , inside the folder "Data" , add a new class "ApplicationDbcontextSeed" for data seeding

            /* End ******************************************************************************************************************/

            #endregion


            #region DbContext with Dependency Injection

            /* Start *****************************************************************************************************************/

            // inside folder "Presistance" , inside "Data" folder , add a new class "ApplicationDbcontext" 
            // don't forget to install packages in the DAL project "Microsoft.EntityFrameworkCore.SqlServer" and "Tools"
            // Notice the new added attribute : "MultipleActiveResultSets" that is = True , Enabling executing more than one query in 
            // one request (will not be added now , will be added next sessions .... )


            // Now how to use Dependency Injection with the DbContext class ?

            // Instead of chaining on the empty parameterless ctor that chains on another ctor that takes "DbContextOptions options",
            // we will chain on the second ctor directly .. and we will give the "DbContextOptions<ApplicationDbContext> options" in
            // the main ctor 

            // Note : options is not configured yet , we will configure it when adding the service to the collection of services that 
            //        will be registered by the CLR (in the program class)

            // Check: ApplicationDbContext , appsettings.json , Program class

            /* End ******************************************************************************************************************/

            #endregion


            #region Adding Migrations

            /* Start *****************************************************************************************************************/

            // Where is the connection string ? => in the appsettings.json file , that is in Presentation Layer (PL) project 
            // so when run the migration we must use the PL layer , then the PL must be the startup project and also the "Tools" package
            // must be installed inside this project

            // Where will be the migrations stored ? => in the "Migrations" folder in the Data Access Layer (DAL) project 
            // so when opening the Package manager console , set the default project to be "IKIA.DAL" project and specify the 
            // output folder that the migrations will be stored in "Presistence/Data/Migrations"

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
