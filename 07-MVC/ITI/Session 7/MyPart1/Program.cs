namespace MyPart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Regions : 

            // Recap : 
            // .Net Framework and .Net Core , versions , problems , advantages and disadvantages 
            // .NET SDK for each OS 
            // IL + SDK of the os => machine language
            // two steps of compilation , and what are the compilers 


            // --------------------------------------------------------------------------------------------------------------------------------------------


            // Deployment : 

            // Deployment types in .Net Core : 

            // 1 - FDD : Framework Dependent Deployment : Folder has => (IL (dll) & dependencies)
            //           - Default deployment in .Net Core
            //           - Dot Net Core SDK "FOR THE OS ON TARGET MACHINE" must be downloaded on target machine (same version of .Net Core SDK of the machine we
            //             Compiled the Code=>IL on. (same version "Major version is important but minor version is not important".)
            //           - Target Runtime is "Portable" (all folder from the developer goes to different OS systems)
            //           - Advantages :
            //                 - Small size folder (has IL and MUST HAVE dependencies only "any third-party dll we use inside our code, or SQL server , ... ")
            //                 - it's the SAME folder (IL , MUST HAVE dependencies) deployed on multiple machines each has it's SDK 
            //           - Disadvantages :
            //                 - Version mis-match 
            //                 - SDK install problems on the target machines
            // 2 - SCD : Self-contained Deployment : Folder has => (IL (dll) & dependencies & .Net Core SDK for target machine OS)
            //           - The folder has IL and MUST HAVE dependencies and Also the SDK part for operating the application FOR A SPECIFIC OS
            //           - Advantages : 
            //                 - No more problems in SDK Versions
            //           - Disadvantages : 
            //                 - for each OS , we will have different folder and files .. 
            //                 - Large folder size
            //           - Target Runtime : Should be specified (Windows / Linux / Mac)


            // how to deploy a console application ? 

            // path of the folder : D:\ITI\Programming - 5 - MVC\7\MyTestDeployment\MyTestDeployment\bin\Release\net10.0\publish

            // ---------------------------------------------------------------------------------------------------------------------------------------------------

            // FDD : 

            // Right click on the project -> Publish -> Folder -> Folder -> select path of the folder

            // before Publishing : Show all settings 
            //  - Configuration : Release            
            //  - .Net 10                            // or the version we are working with
            //  - Framework dependent                // first type we discussed above
            // Click Publish 

            // go to the path and you will find 5 files : 
            // - dll file
            // - 2 JSON files for the configuration 
            // - .exe file because we work with windows console app
            // - .pdb file 


            // ---------------------------------------------------------------------------------------------------------------------------------------------------

            // SCD : 

            // Now we will publish with the other type : 
            // Right click on the project -> Publish -> new profile -> Folder -> Folder -> select path of the folder (make other folder)

            // before Publishing : Show all settings 
            //  - Configuration : Release            
            //  - .Net 10                            // or the version we are working with
            //  - Self-Contained                     // second type we discussed above
            //  - Target Runtime                     // the OS of the target device (windows x64 or x86 , linux , mac)
            // Click Publish 

            // go to the path and you will find 192 files !!!! because it's self contained deployment (they are downloaded , they are part of the .Net core Linux sdk)


            // ---------------------------------------------------------------------------------------------------------------------------------------------------


            // how to deploy a web application ? 

            // it's the same as deploying console app but with additional step for hosting it on IIS or what server , we can do this by many ways ... 


            // Now we will take the folder that is published and PUT IT ON A SERVER , this server has some settings 


            // --------------------------------------------------------------------------------------------------------------------------------------------------

            // some steps that are done ONE TIME
            // 41:00  to  51:00 

            // Step 1 : ------------------------

            // control panel -> Programs -> turn on features on or off -> check these settings : 
            // 1 - Internet Information Services 
            //       - Web Management Tools 
            //              - IIS management console (check it)
            //       - World Wide Web Services 
            //              - Common http features (check all)
            //              - Application Development Feature 
            //                     - .Net Extensibility 4.8    (check it)
            //                     - ASP.NET 4.8               (check it) 


            // Step 2 : ------------------------

            // Download and Install .Net hosting bundle from Microsoft website with the version of .Net we are working with.


            // Step 1 and 2 are done only one time , now our device can work as a server. 

            // Note : After step 1 and 2 , restart the device , and when working with IIS always run as adminstrator to avoid errors


            // ---------------------------------------------------------------------------------------------------------------------------------------------

            // now we will deploy the previous Demo for the previous session , open that project , publish it as we did with the console app (FDD)

            // when navigating to the folder we will find 
            //  - dll file 
            //  - static files (wwwroot files)
            //  - dependencies for making .Net core web app works (efcore , .. )
            //  - folders for languages (Humanizer.dll) 

            // this folder is the folder we take and put on the server to run there (because it's a web application not a console app as we did before)

            // 1 - take the path of the folder (inside the folder in the path of all files and folders (ex: dll, languages, ... ))
            // 2 - run IIS as adminstrator 
            // 3 - Navigate to Sites -> Default Web site , and apply some settings here that will be applied on any hosted app on the default web site
            // 4 - before applying the setting , right click on default website -> Add application -> give an alias name for the website -> put the path here
            //     my path : D:\ITI\Programming - 5 - MVC\6\My\My\bin\Release\net10.0\publish\MVC_FDD
            // 5 - click on Default Web Site -> double click on the Directory Browsing -> Enable

            // now we have a problem because we cannot access the application , we must first add a IIS User 

            // 6 - right click on the website alias name -> security tab -> Edit -> Add -> Advanced -> Find Now -> Select (IUSER and IIS_IUSERS) 
            //     -> Then select each added user and make permissions "Full Control"

            // 7 - Any thing related to database and SQL Server will not work (because we wrote in the Connection string "Integrated Security = true") , this 
            //     means that when working with this DB , the users are connected Windows authentication (this doesn't matter in development time) , now this 
            //     app is hosted on a server and the users are connected using IIS authentication. So to solve this problem we must make the user of the DB as
            //     the SQL User (and we will make it SA)
            //     old connection string : "Data Source=.;Initial Catalog=Std_Dept_Demo6_DB;Integrated Security=True;Trust Server Certificate=True;"
            //     new connection string : "Data Source=.;Initial Catalog=Std_Dept_Demo6_DB;User=sa;password=123;Trust Server Certificate=True;"
            //     
            //     Note : you must make some configurations for allowing login with SQL Authentication (google it !) + resetting password of SA if not known ! 
            // 
            // Note : We must add any change in any view or controller , and then re-publish to make the website feel that there is a change !
            //     Then re-publish the app and do the same work again with changing the Folder that the websiteAliasName will read from (new publish folder so
            //     new publish path) -> right click on the website alias name -> manage application -> Advanced Settings -> put the new path in the physical path
            //     Then do step number 6 again because we will add the permissions again

            // Now the website is hosted successfully ! 

            // right click on the website alias name -> Manage application -> Browse !
            // Note : we can access our website from other device ON THE SAME NETWORK using IP of the device that has the server/websiteAliasName
            //        ex: 10.145.4.137/myWebApp          (know IP -> cmd command ipconfig -> IPv4 Address)


            // note : when making a publish more than one time , at each time a new "FolderProfile" is added to folder "Properties/PublishProfiles" ...  


            // --------------------------------------------------------------------------------------------------------------------------------------------------


            // Part 2 (After First Break) :

            // Things related to .Net Core : 


            // Any .Net core application has some settings , pre-configured settings inside some json files , and other coded settings that can be added inside 
            // the code. 

            // launchSettings.json : discussed before (and muse self-study more) , has Environment Variables that has "ASPNETCORE_ENVIRONMENT": "Development"
            //                       value could be "Staging" , or "Production" or "OtherStringWeWillWrite" , the string we will write is used to write some 
            //                       code in the code files.

            // we use this "ASPNETCORE_ENVIRONMENT" data to make things when knowing that i am in a specific environment , ex: show errors for user IF IAM IN THE
            // DEVELOPMENT MODE , otherwise don't show errors. 

            // see code inside the program file , inside the main function , these are some coded configurations : 

            // if (!app.Environment.IsDevelopment())
            // {
            //     app.UseExceptionHandler("/Home/Error");
            // }

            // it could be : 
            // - if (!app.Environment.Production())
            // - if (!app.Environment.IsStaging())
            // - if (!app.Environment.IsEnvironment())        // takes the "OtherStringWeWillWrite" and configure it as an environment in the launchSettings.json

            // so in the previous code , if we are not in the development environment then show this page (actually it doesn't show the error details for security
            // reasons .... )

            // Ex: 

            // if (app.Environment.IsDevelopment())
            // {
            //     app.app.UseDeveloperExceptionPage();            // for showing all exception data and details (because we are inside the Development Env.)
            // }

            // Ex:
            // in development env we are working with a database that is for development , but in production we work with another database ! So this can be 
            // applied here (and will be discussed later).



            // --------------------------------------------------------------------------------------------------------------------------------------------------


            // Dependency Injection : 


            // Association , Aggregation , Composition : 
            // Aggregation : Notebook & Paper (Life time , no dependency) (Both can be used when separated)
            // Composition : Car & Motor (Life-Death , Full dependency and tightly coupled)

            // our mission : apply SOLID principles , without being tightly coupled

            // O in SOLID => Open closed principle (code should be open for extension but closed for modification) , that means adding and extending the code 
            //               without changing the previously written code.

            // Build against abstractions not concrete implementations.


            // .Net core has a built-in dependency injection system


            // DI : we have low level classes that impelement an Interface , and the high level classes has an instance of that Interface 
            //      ex:
            //      - High Level class (Notification, has reference of interface)
            //      - Interface (IMessage , has function "Send")
            //      - Low level classes (Gmail, whatsapp, slack, ... , each implement it's Send message)
            // 
            // So in runtime I WILL INJECT an object of low level classes that i want to use. 

            // Types of injection : 
            // 1 - Constructor Injection 
            // 2 - Method Injection (public method)
            // 3 - Property Injection (or Attribute Injection)

            // in .Net Core , we use the "Constructor Injection" in most cases.


            // Note : Design patterns are not final solutions , we can customise it more to solve our problem in a better way. 
            //        In .Net core we extended the Dependency Injection and added a Dependency Injection container , this container has the classes that are 
            //        allowed to be injected, This is the constraint that is added by the .Net Core , that we must add the class (or service) to the DI container


            // ------------------------------------------------------------------------------------------------------------------------------------------------

            // Part 3 : second video 


            //Note : Delete "my" if empty 












        }
    }
}
