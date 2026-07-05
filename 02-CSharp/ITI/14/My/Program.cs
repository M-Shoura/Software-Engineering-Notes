namespace My
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
            Application.Run(new Form1());
            Regions();
        }

        private static void Regions()
        {
            // ComboBox : is used for making a drop down list , and also we can use it to have a seen value and another value behind 
            //            used for making insertion , updating , and deleting easier
            // DataGridViewComboBoxColumn pubColumn = new DataGridViewComboBoxColumn();
            // pubColumn.DataSource = dataTable;        // Fill it using a data table 
            // pubColumn.DisplayMember = "pub_name";    // what will be displayed in the drop down list 
            // pubColumn.ValueMember = "pub_id";        // the value that I will use later 
            // pubColumn.DataPropertyName = "pub_id";   // for the complex binding in the resulting table , the selected Id
            //                                             value == corresponding combo box (any change , changes the other one)

            // if we try to make this with a Join , then it will be "read only" , without insert or update or delete ! 

            // now starting building the architecute of the solution and projects , because this is spagetti code ! 
            // we will work with 3-tier architecture , this makes the changing easier as we can change the UI layer without changing
            // other layers , but here in our case the whole code is written in the UI so if we want to change this project to be a 
            // mobile application OR change the Database Provider (change from MSSQL to Oracle) then we must re-write the whole code ,
            // as it's tightly coupled code. 

            // database (tables , SP , views , ... )
            // layer 1 => class library project (Data Access layer) , the only layer dealing with database
            // layer 2 => class library project (Business Logic layer) , contains Entites , EntityLists , EntityManager (contain CRUD) 
            // layer 3 => Windows forms project (UI layer) 

            // the BLL sends an Sp name and/or data to the DAL , then the DAL returns an int , Object , DataTable to the BLL again 
            // then the BLL sends to the UI layer Business Entities 
            // Note : we can have more then 3 tiers , depends on the requirements !

            // How to make layers interact with each other ? by adding project referernces
            // in the BLL , add project reference to the DAL , so that we can call functions in the DAL inside BLL

            // - inside the DAL , we will make a class called "DatabaseManager" that interacts with the database 
            // - inside the BLL , we will make three folders for "Entites" , "EntityLists" , "EntityManagers"
            // - inside the UI  , we will have the Configuration file that contains the connection strings (this is the project that runs)

            // Note : because the DAL is a class library project type , we must install the "System.Configuration.ConfigurationManager" to 
            //        be able to get the connection string from the configurations file

            // Note : in the DAL , it doesn't depend on the business , and it has 3 functions to start with : 
            //        - public DataTable ExecuteDataTable (string SPName)
            //        - public object ExecuteScalar (string SPName)
            //        - public int ExecuteNonQuery (string SPName)


            // Note : when running , an error will occur if there is not a configuration file in the UI project (the project that runs).

            // Note : here we don't have the state that changes when adding or deleting or updating the entry , so we must implement it 
            //        our selfs. 
            // in our case here i will implement it only with the employee fname , IT MUST BE IMPLEMENTED WITH ALL OF THE PROPERTIES OF
            // THE EMPLOYEE CLASS !! 
        }
    }
}