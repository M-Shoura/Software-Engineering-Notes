namespace MyAndAssignment
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmDisconnectedModeList());
            Regions();
        }

        private static void Regions()
        {
            // Now starting with ADO.Net , and using Windows forms for visualizing it ! 

            // Note : .Net Core is cross platform , BUT windows forms and WPF are windows only ! because no equavilant for the controls 
            //        in other operating systems ! So having Windows forms in .Net core allows us only to use the latest C# versions 
            //        but not being cross platform.

            // EFCore has some overhead , because of the additional steps it adds to execute the query, we can write SQL or call SP 
            // directly if we want. 

            // EFCore is build over ADO.Net , so we take ado to know the underlaying structure of the EFCore. And also if we want the 
            // max speed so we can go with ADO ! 

            // Note : a tool for faking data and inserting it in the database to make benchmarking easier : Bogas.net 

            // ADO.net => Some classes and namespaces

            // ADO and EFCore are working with "Provider Based" , so we choose the DB Provider and see if it's supported or not.
            // Provider => set of classes and interfaces that allows me to deal with this Database (MS SQL , MySQL , Oracle , ... ) 

            // if we don't have the dll of the provider of the database , then we have "ODBC" Provider , and "OLE" Provider , these are
            // interfaces that all relational databases follow one of them . some features are there in the SQL provider that are not in 
            // the ODBC provider for example , so it's better to use the provider of the DB that we use.

            // ADO has 2 modes : 
            // - Connected Mode : The connection between the application and the database must be OPENED ! This mode is "Read-Only" Mode , 
            //                    and when working with layered architecture we will see that it's not possable to maintain the connection
            //                    between the all layers ! 
            // - Disconnected Mode : Most Working is with this mode , note that this data is probably not the latest version , the data may
            //                       have been changed 


            // As a naming convnetion : 
            // - Table => Plural 
            // - Object => Singular
            // - ObjectList => Plural


            // Starting with ADO.NET => install the .dll first or the package from the nuget package manager "Microsoft.Data.SqlClient" , 
            //                          So when installing the package and building the project we will find the package dll in the 
            //                          bin=>debug=>.net version. (actually they are many .dll files for many packages that interact with
            //                          each other , it's NOT the Microsoft.Data.SqlClient.dll )
            //                          Now we can write "using Microsoft.Data.SqlClient" in our file above the namespace.

            // we can install the packages also using the package manager console , which is a powershell interface that we can write 
            // commands in it , ex: "install package Microsoft.Data.SqlClient" and now it will install the latest version of this package.

            // Data Table : when wanting to save some rows and columns in the application , as a result from a query or result of a form 
            //              or any other thing , then we save this data in a datatable in the application ! it's not SQL , oracle , or any
            //              other thing. and can be found in the System.Data directly 

            // Connection string : a property in the "sqlConnection" object , Note : we can know the connection string for each database 
            //                     from "connectionstrings.com" website.

            // SQL Command : we wrape the SQL query in a SQL Command , this sql query can be a plain text , or Stored Procedure , or ....

            // how to execute the SQL Command ? this is different between the connected and the disconnected mode 

            // with ADO here we will use Stored Procedures because it's faster and more secure , but with Dapper (micro-framework) or with 
            // EFCore we will not usually work with SP 

            // After connecting to the database now we can make an operation but first choose the mode of the connection : 
            // Connected mode    : With ADO , then we are working with "Read Only" as selecting data only without insert , update , delete
            //                     and to work with this mode we use object called "SqlDataReader" that reads the data row by row from the
            //                     database , AND DOESN'T SUPPORT THE DATA BINDING because it doesn't implement the IList interface. 
            //                     Note : the connection must be opened to see data , once it's closed then we cannot see the data.
            //                            and the opening and closing of the connection is MY RESPONSABILITY AS A DEVELOPER.    
            // Disconnected mode : we now work with "Read and Write" , to work with this mode we use object called "SqlDataAdaptor" which is
            //                     a collection with 4 commands : SelectCommand , InsertCommand , UpdateCommand , DeleteCommand. 

            // When getting the data from the database we put it in the DataTable (discussed before) , which is "Rows" and "Columns".
            // The DataTable is used with the Disconnected Mode. when filled with the SqlDataAdaptor then it comes with the same structure
            // of the database , otherwise it can hold System.Object value (Any data). Now the table is an offline copy of the data in 
            // our application. This Datatable is binded to the UI controls (textbox , Grid , List , ... ) , we can insert , delete , update
            // data in this DataTable and when telling the application to "Update" then we will see what has changed (updated) , what have 
            // been added and what have been deleted and then reflect these changes on the actual database !

            // Note : we can have more than one DataTable in our application , and before having datatables , we had DataSet that was
            //        very bad and we will not use it ever ! 

            // In ADO we will generate every thing , ex: making tables and SP and views and then in the application make the Entites
            // and the Entity manager and get data from the database and handle mapping between types and ..... 

            // starting : 
            // make an object of type "SqlConnection" in the class and we can use it in any function in the class , and initialze it in the
            // function Form Load , the object of type SqlConnection has a ctor that takes the connection string (must be written in the
            // right way)

            // search : why do we need the Application Configuration File ? 

            // When we want to change some data that will be used in the application live ... then we can put this data in a file that is
            // not required to be built , so we can get the data directly from this file when we want it ... this file is called the 
            // configuration file (XML or JSON) , that contains key value pairs , and this file will be in the folder of the release and 
            // deployment , so if we want to edit this file we will edit it in the file directly not necessary to have the visual studio.

            // Based on the technology we are using we will know the type of the file , so here we will add a file =>
            // "Application Configuration File" which is a XML file , this file has a section for connection strings that we can use 
            // directly as i did here in the Application Configuration File (note : any thing here must be written correctly because this
            // will not show an error) .... so now we will not put the connection string in the C# code , as changing it required re-building
            // the application again ! 

            // to put other data , we use the "appSetting" tag , that is a key value pair (ex: done with the branch id)

            // to read data from this file : use the ConfigurationManager class 
            // ex: ConfigurationManager.ConnectionStrings["pubs"].ConnectionString;
            //     ConfigurationManager.AppSettings["BranchId"];                      

            // so now we can change any data that is used in the application without changing the C# code and re-building the application , 
            // and also we will put here the connections strings and sensitive data without putting it in the C# code becuase it can be
            // easily known by reversing the code from IL to C# again ! (Note : the sensitive data must be encripted)

            // See example in the frmConnectedMode .... (Important)

            // Note : if we have more than one form then we must choose the startup form , in the main function 
            // Application.Run(new Form1());     // or new FormClassName() , creating an object from the form .. 

            // Note : with connected mode , we can apply binding but when putting the data in another objects ... see example of updating the job level of an employee



            // -------------------------------

            // See example in the frmDisconnectedMode .... (Important)
            // example of working with the "Disconnected Mode"
            // it's like an excel sheet for showing employee table , shown in a "Grid" in the UI called "Ddata Grid View" , with a 
            // menu strip


        }
    }
}