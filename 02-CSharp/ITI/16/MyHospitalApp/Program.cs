using MyHospitalApp.Context;
using MyHospitalApp.Entities;

namespace MyHospitalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Code First or Code Only approach : 

            // to work with this approach , we first must : 
            // - Install Microsoft.EntityFrameworkCore.SqlServer
            // - Install Microsoft.EntityFrameworkCore.Tools
            // - Install Microsoft.EntityFrameworkCore.Design

            // first of all , start adding a migration (which will be empty) , and name it IniticalCreate ! 
            // command for adding a migration (project must build and have no errors) : 
            //     - add-migration MigrationName
            //
            // we now get a new folder "Migrations" having 2 files , first file has name = timeStamp + MigrationName , we will notice that 
            // any migration class is a partial class and has 2 functions : Up and Down , up for applying the migration on the DB , down 
            // when reverting and rollbacking this migration from the DB. Second file is the "Snapshot" file , it's used when adding
            // migration , we compare the differences between the DbContext class and the Snapshot , so this will be the change in the
            // next migration !

            // Note : Adding migration doesn't mean that the changes are reflected to the DB

            // How to apply the migrations to the DB ?
            //    1 - Write command update-database in Package Manager Console
            //    2 - Write in the main function or the source code "Context.Database.Migrate();"
            // Note : editing source code may be not available so we can use PMC.

            // command : update-database                     => update to the latest migration
            // command : update-database "MigrationName"     => update to the given migration 
            // command : remove-migration                    => removes the last migration
            // 

            // what happens in the mirst update-database : 
            // if there is not a table called "EFMigrationHistory" then create it to track the history of applied migrations , we
            // shouldn't edit in this table , this table maintains "DB on what version" and "Classes and application on what version" , 
            // versions == migrations


            // start making the entities 

            // Note : why we are making navigarional properties as virtual ?
            //        Old EF => to make it Lazy Loading
            //        Nowadays => if we will inherit in the future and override 

            using HospitalContext context = new();

            context.Departments.AddRange([ new() { Name = "ICU" }, new() { Name = "Hr" }]);

            Console.WriteLine(context.SaveChanges());

            // Now a very important Question , where is validation handled ? (ex: maxLen < 40 , ... ) in the application or in DB or where ?
            // we will notice that we have some validations in C# and data annotations (ex: Range , MinLen) that is not available in SQL , 
            // and after making the migration and applying it to DB we notice that these non-available validations are not in the DB , 
            // so if SQL enforce these validations then OK , else it's your task to enforce them as a developer ! maybe in the frontend or 
            // in UI or in the BLL layer

            // Note : in Old EF before EFCore , it was applying the validations in EF , but this was an overhead as we usually validate the 
            //        date before going to the layer of DB (incase of working with layered arch in modern applications) , so we must 
            //        validate on these data earlier.


            // [Range(18,99)] : this is a validation and data annotation that cannot see it's effect in Console applications or Windows 
            //                  forms , but can be used in ASP.NET MVC and APIs
            // so here if age value = 15 , it WILL NOT VALIDATE IT , and SQL WILL NOT VALIDATE IT because nothing in SQL called Range 
            // Note : We have in DB "Check Constrains" but this must be done manually ! 


        }
    }
}
