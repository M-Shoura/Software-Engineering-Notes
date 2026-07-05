using SchoolConsole.Context;
using SchoolConsole.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // How can we add configurations for classes we don't have their source code ? 
            // these classes are called "POCO Classes" (Plain Old C# Objects) which we may have the source code but it's not allowed 
            // to add annotations in it. 

            // so we now will use Fluent-APIs and configuration classes , Fluent-APIs can be written in the function of DbContext
            // "OnModelCreating" , but Configuration class is making classes for each type and call them inside the OnModelCreating function.


            //------------------------------------------
            // 3 - Fluent-APIs : 

            // some fluent apis : 

            // configurations for the database : 
            // ............
            // ............


            // configurations for a specific entity : use .Entity<EntityName>()
            //
            // modelBuilder.Entity<Teacher>().HasKey(x=>x.TID);
            // modelBuilder.Entity<Teacher>().ToTable("SchoolWorkers");
            // modelBuilder.Entity<Teacher>().Ignore(x=>x.CreatedOn);
            // ............
            // ............


            // configurations for a specific property in an entity : use .Entity<EntityName>().Property
            //
            // modelBuilder.Entity<Teacher>().Property(p => p.FName).HasMaxLength(100);
            // modelBuilder.Entity<Teacher>().Property(p => p.FName).IsRequired();
            // modelBuilder.Entity<Teacher>().Property(p => p.Salary).HasColumnName("MonthlySalary");
            // modelBuilder.Entity<Teacher>().Property(p => p.Salary).HasColumnType("money");
            // modelBuilder.Entity<Teacher>().Property(p => p.Age).HasDefaultValue(21);
            // modelBuilder.Entity<Teacher>().Property(p => p.Address).IsUnicode(true);
            // ............
            // ............


            // writing configurations in the new way : 
            //
            // modelBuilder.Entity<Teacher>(builder =>
            // {
            //      builder.HasKey(x => x.TID);
            //      builder.Property(p => p.FName).HasMaxLength(100);
            //      .........
            //      .........
            // });


            // Note : note that based on the property type we choose , we have a set of valid functions for this type , ex: for "string"
            //        we have .HasMaxLength() , but this is not found for "int"


            // it's not a must to put the nav property in the two sides , if one side has the many then it's not a must to put the other 
            // side if it's a "One". There are many cases , try and see them ! 


            // self study : hasDefaultValue VS hasDefaultValueSql.


            //------------------------------------------
            // 4 - Configuration classes : 

            // we make a class that implements the interface "IEntityTypeConfiguration<>" , and give it your type , then we will have a 
            // function called "Configure" 



            // ---------------------------------------------------------


            // we can use an attribute inside the class of type Enum (it will be int), but we cannot use the "struct" to be a mapped entity
            // or a complex type , all of them must be classes.




            // using SchoolContext context = new();
            // context.Departments.Add(new Department() { Name = "Math", Location = "First Floor" });
            // context.Departments.Add(new Department() { Name = "IT", Location = "Second Floor" });
            // 
            // context.Teachers.Add(new Teacher() { FName = "Mahmoud", LName = "Shoura", Age = 24, 
            //                                      Address = "Cairo", Department = context.Departments.Local.First() , Salary = 5000 });
            // Console.WriteLine(context.SaveChanges());

            // note : in Department we used "Local" , because till now we didn't save changes in the DB , and the saveChanges works in a 
            //        transactional way (all succeeded or failed)



            // Migrations : 

            // to remove the migration use command (but before applying that migration to the DB) : remove-migration 


            // Migration Class : 
            // inside the migration class we can write SQL , using the .Sql 
            // ex: migrationBuilder.Sql(""" update SchoolWorkers set FullName = FName + ' ' + LName """);
            //
            // And also we can make any changes in the migration folder , ex : instead of droping a column and making other one , we can 
            // rename the column it they have the same datatype and length (if they are strings)

            // after changing in the migration file , update-database ! 

            // to script the SQL Code for all migrations , so we can use this code and execute it our selfs, use command : script-migration 


            // --------------------------------------------------
            // Inheritance : TPH , TPCC , TPC

            // when having a hierarchy of classes , how to show them in the DB ? 

            // Note : No Data Annotations for making these configurations 

            // Case 1 : 
            // if we have a non-abstract class that the types inherit from it : 
            // make 3 DbSets one for each type , we will see that the EFCore will make a TPH (Table per hierarchy) that has a Discriminator
            // Ex: Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false) 
            // to make us able to differentiate between types , it will store the name of the type ex: "WalkInStudent" or "FullTimeStudent"
            // or "Person" ... So this is the default if we didn't write any Data Annotations

            // using SchoolContext context = new();
            // Person person = new() { Name = "Mahmoud Shoura" };
            // FullTimeStudent fullTimeStudent = new() { Name = "Ahmed", Grade = 4, EnrollmentDate = new DateOnly(2025, 2, 20) };
            // WalkInStudent walkInStudent = new() { Name = "Sayed", CourseCode = "En101" };

            // Insert => insert and in the Discriminator put the name of the type 
            // context.Add(person);
            // context.Add(walkInStudent);
            // context.Add(fullTimeStudent);
            // Console.WriteLine($"{context.SaveChanges()} Rows Affected");


            // Select => we can select from the DbSet we have and EFCore will know the type and will filter with the name of the type with
            // the Discriminator , or if we don't have the DbSet then use "OfType<Type>()" that will make the same things : 
            // Note : if it's a single DbSet then i must write fluent Apis to tell that it's a TPH
            //        ex: builder.HasBaseType<Person>();

            // incase we have a DbSet : 
            // Console.WriteLine(context.FullTimeStudents.FirstOrDefault().Name);

            // incase we don't have a DbSet but we wrote Configuration to tell efcore that this entity has a base type : 
            // Console.WriteLine(context.People.OfType<FullTimeStudent>().FirstOrDefault().Name);

            // What if i don't want the EFCore to make a Discriminator and i want to make my own ? 
            // then i must write fluent apis to demonstrate the values of the Discriminator : 
            // in the base class : 
            // builder.HasDiscriminator(p => p.IsEnroller).HasValue<Person>(1)
            //                                            .HasValue<FullTimeStudent>(2)
            //                                            .HasValue<WalkInStudent>(3);


            // What if we want to make it
            // - TPCC (Table Per Concrete Class, in EF it's called TPC) 
            // - TPC  (Table Per Class , in EF it's called TPT Table Per Type)

            // Note : We may have errors when changing the type of mapping , so it's better to make a migration that Drops all tables , 
            //        and then re-create them again in the next migration , dropping the tables can be done easily by commenting the DbSets
            //        and also the configuration classes to avoid creating the types 

            // Note : With TPT , even if the base type was an abstract class but EFCore made a table in the DB for it ! 

            // Summary : remember the advantages and disadvantages of working with each type , and test in EFCore as more as you can ! 



            // ------------------------------------------------------------------------------------------------------------------------


            // Part 2 : 

            // See NorthwindConsoleApp ! 










        }
    }
}
