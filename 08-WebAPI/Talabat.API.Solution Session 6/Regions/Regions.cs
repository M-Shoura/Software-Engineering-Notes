namespace Regions
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // Search : All relationships are one mapped to a 1 to many Relationship
            // Why the EFCore wants an empty ctor in each entity it will be mapped to table or entites used inside other entities mapped
            //      to tables ?

            // Add VS AddAsync , and why there is no UpdateAsync or RemoveAsync
            // Microsoft Docs : https://stackoverflow.com/questions/42034282/are-there-dbset-updateasync-and-removeasync-in-net-core
            // Microsoft Docs : https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-9.0#Microsoft_EntityFrameworkCore_DbSet_1_AddAsync__0_System_Threading_CancellationToken_
            // Microsoft Docs : https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addasync?view=efcore-9.0#microsoft-entityframeworkcore-dbset-1-addasync(-0-system-threading-cancellationtoken)


            // ValueTask and Task , in asynchronous code 

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with Order Module

            /* Start *****************************************************************************************************************/

            // The order is a complex object , contains many entities .. 

            // Order Module : make a new folder "Order Aggregate" inside Core project and add =>
            // 1 - Order 
            // 2 - Order Item 
            // 3 - Order Status (Enum)
            // 4 - Address : Address of the order it self , will have default value as the address of the user (implemented last session) , 
            //               and can be changed if we want
            // 5 - Delevery Method


            // Note : [EnumMember] data annotation is used to store the Enum value in the database as the string defined above it , not the 
            //        int value 0 or 1 or , but we must write some configurations for it first (discussed after multiple lines ..)

            // Note : Some Entities will be mapped with Owner , not as a different table in the database (must write some configurations
            //        for it first , discussed after multiple lines ..)


            // Derived attribute , can be implemented by two ways : 
            // 1 - Readonly property (only get) + [NotMapped] data annotation
            //     Ex: 
            // 
            //     [NotMapped]
            //     public decimal Total { get { return SubTotal + DeliveryMethod.Cost; } }
            //        or (new syntax)
            //     [NotMapped]
            //     public decimal Total => SubTotal + DeliveryMethod.Cost;
            //
            // 2 - getter method (start with "Get" , to be automatically mapped later when using order DTO GetTotal mapped to Total in DTO)
            //     This is a derived attribute 
            //     Ex:
            //
            //     public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;


            // Why we have an empty constructor in each entity of the order module ?
            // The EFCore (When making migration) wants a accessable empty parameterless constructor for classes that will be mapped to table 
            // or classes used inside classed mapped to tables so we will make empty constructors for all the classes we've made in order module
            // These Ctors can be private also , to have only by the efcore when generating tables and forcing users to use the other ctors

            // Note : Security Issue
            // Why we have BuyerEmail instead of BuyerId in the Order Class ? (Email contained in the Token)
            // To prevent a user to see orders of another user if he got his id , instead we can verify that the email that came from
            // the Token = BuyerEmail of the order .. so no user can see orders of another user unless he logged in with his account.
            // So if the BuyerId is contained in the Token then The two properties are the same and prevent any security issue

            /* End ******************************************************************************************************************/

            #endregion


            #region Order Module Fluent APIs Configurations

            /* Start *****************************************************************************************************************/

            // Code written in : OrderConfigurations and OrderItemConfigurations and DeliveryMethodConfigurations

            // 1 - Shipping Address is mapped with Owner (Order) [1-1] Total participation from 2 sides
            // Code :
            //          builder.OwnsOne(o => o.ShippingAddress, shippingAddress => shippingAddress.WithOwner());



            // 2 - Status stored in the database as strings , and when retrieving converted to the Enum type again
            // Code :
            //     builder.Property(o => o.Status)
            //            .HasConversion (
            //                x => x.ToString(),                                        // When saved in the database
            //                X => (OrderStatus)Enum.Parse(typeof(OrderStatus), X)      // When retrieved from the database 
            //             );
            //     


            // 3 - Product Item Ordered is mapped with Owner (OrderItem) [1-1] Total participation from 2 sides
            // Code : 
            //          builder.OwnsOne(o => o.Product, product => product.WithOwner());



            // 4 - Making "On Delete" => "Set Null" with the relationship between Delivery Method and Order
            // Problem is with the FK (that we wrote OR the default generated by efcore in the database directly ... )
            // 
            // Code : we have three ways , one with Writing the Foreign Key and two without writing the FK
            //   1 - Writing Foreign Key (we didn't use this way as we commented the foreign key in the Order Class)
            //        Make the FK nullable (ex: public int? DeliveryMethodId { get; set; } )
            //           and
            //        writing configurations (ex: builder.HasOne(o => o.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull); )
            //   
            //   2 - Without writing FK , After making the migration ,
            //       in migration file: make the FK column (Column<int?>) and (nullable : true)
            //                         (ex: DeliveryMethodId = table.Column<int?>(type: "int", nullable: true), DON'T CHANGE type .. it's SQL)
            //       in the Snapshot file: make the FK property (type = int?)
            //                            (ex: b.Property<int?>.HasColumnType("int");  DON'T CHANGE HasColumnType .. it's SQL) 
            //          and 
            //      writing configurations (ex: builder.HasOne(o => o.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull); )
            //
            //
            //   3 - Without writing FK : The easiest way .. Make the navigational property Nullable and the FK generated will be nullable !
            //      (ex: public DeliveryMethod? DeliveryMethod { get; set; })
            //          and 
            //      writing configurations (ex: builder.HasOne(o => o.DeliveryMethod).WithMany().OnDelete(DeleteBehavior.SetNull); )

            /* End ******************************************************************************************************************/

            #endregion


            #region Migrations and Data Seeding

            /* Start *****************************************************************************************************************/

            // Now adding Migration :

            // - The startup project must be the project that has the appsettings , because it has the connection string of the database 
            //   And also the package must be installed in the startup project "APIs" project
            // - Migrations are Put in the "Repository" Project , so choose it as the default project 


            // Important : If we didn't make DbSets for the new added entities of Order Module , then the EFCore will automatically make 
            //             tables for them in the database .. that's because we used and implemented the IEntityTypeConfigurations and 
            //             configured the entities and the relationships between them , and in the "OnModelCreating" function we 
            //             applied configurations from Assembly (and when using these DbSets .. DbContext.Set<Order>() .... )



            // Now Data Seeding : 

            // Names in the JSON file must be the same names of properties in the class 
            // Same as we did with other classes , see class "StoreContextSeed" , and program class after configuring services .. when 
            // applying migrations and data seeding

            /* End ******************************************************************************************************************/

            #endregion


            #region Entity Framework Core (EFCore) Notes  

            /* Start *****************************************************************************************************************/

            // in the level of database , any relationship is One-To-Many , How ?
            // Many-To-Many Relationships => 1-many and 1-many
            // One-To-Many Relationships => 1-many 
            // One-To-One Relationships => 1-many and the FK Unique 


            // in EFCore , if we write navigational property one in one side , and the other side of the relationship empty
            // Then it's a 1-many relationship in the database unless we put a unique constraint on the FK so it will be 1-1


            // if we want to make a [1-1] relationship then make a unique constraint on the foreign key ... and can be done with other
            // way also : 
            //   1 - builder.HasOne(...)
            //        .WithOne();            // This will make a unique constraint by default
            //
            //   2 - builder.HasIndex(FK).IsUnique();


            // Create table in the database : 
            // 1 - Add DbSet 
            // 2 - implement the IEntityTypeConfigurations


            /* End ******************************************************************************************************************/

            #endregion


            #region Order Service

            /* Start *****************************************************************************************************************/

            // We will implement the order module Functionality :
            // 1 - Create Order
            // 2 - All Orders for specific User
            // 3 - Specific Order for a specific User
            // 4 - Get All Delivery Methods

            // Note : We can have more than one implementation for these 3 functionalities .. ex: if a user is a VIP user then the 
            //        implementation will be different than if the user is a normal user , so using the interface here will help us 
            //        in this situation 


            // Once we talk about Business , then we will use a Service (in the service layer)


            // The Service Interface will be in the Core Project (as it contains all the project not implemented)
            // We will implement this interface in the Service layer , and to make this task easier .. imaging the steps of making
            // an order and try to implement it , ex: 
            // 1 - Get Basket from Baskets Repo
            // 2 - Get Selected Items at basket from Products repo
            // 3 - Calculate SubTotal
            // 4 - Get Delivery Method from DeliveryMethods repo
            // 5 - Create Order
            // 6 - Save to Database 

            // Notice when we try to add the order in the repository we don't have "Add" or "Update" or "Delete" methods !! 
            // We will add them now in the generic repository interface and class
            // Note : We have "Add" and "AddAsync" , but we have "Update" and "Remove" only without Async Versions .. so when we will 
            //        use the Async Version of Add?  ===> When the PK is having a Sequence , ex: pk = ORDER-[MonthName]-[OrderNumber] 
            // Microsoft Docs : https://stackoverflow.com/questions/42034282/are-there-dbset-updateasync-and-removeasync-in-net-core
            // Microsoft Docs : https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1?view=efcore-9.0#Microsoft_EntityFrameworkCore_DbSet_1_AddAsync__0_System_Threading_CancellationToken_
            // Microsoft Docs : https://learn.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbset-1.addasync?view=efcore-9.0#microsoft-entityframeworkcore-dbset-1-addasync(-0-system-threading-cancellationtoken)


            // Notice also when trying to save the order in the database, we couldn't do this now .. We need First to implement
            // the Unit Of Work design pattern

            /* End ******************************************************************************************************************/

            #endregion


            #region Unit Of Work

            /* Start *****************************************************************************************************************/

            // Unit of Work : A Class (as a unit) that represents our work with Database through the DbContext
            // Remember : DbContext is the class responsible for working with Database

            // if we implemented "SaveChanges" inside "Add" , "Updata" and "Delete" , then if we added and deleted , "Save Changes" will
            // be executed 2 times .. This is bad , We want to save changes 1 time after making all of the Adds , Updates , Deletes

            // Note : We can have more than one UnitOfWork class , incase we have more than one Repository Layer (more than one
            //        DbContext) , this will happen if we have more than one Database
            //        

            // So , in Core Project , add the interface "IUnitOfWork" that implements the "IAsyncDisposable" interface for dispose connection
            // and in Repository project , add class "UnitOfWork" that will implement the interface "IUnitOfWork" , and ask the CLR to provide
            // an object from storeDbContext , to be able to implement "Complete" and "Dispose" functions

            // Must See the Old way (Class Old_UnitOfWork) and the new way (Class UnitOfWork) 
            // Old Way : Inside the Interface we add property signature for each and every repository + the CompleteAsync Method 
            // New way : Make a dictionary that holds the generic repositories of all types , and make a function that creates a repository 
            //           per request , and stores it inside the dictionary 
            //           - We used dictionary to follow the "Open Closed" Princple , now if a new repository is added nothing will be affected
            //             unlike using the old implementation that we must make a property for each repository we have 


            // Note : We didn't make a UnitOfWork class for the In-memory database , because it only contains ONE Repository

            // Now after finishing the UnitOfWork , our Order service will work with the unit of work class , not with each repo 
            // Don't miss adding the services in the "Program" class , and now it's not important to add services for generic repo , as 
            // we explicitly make a new object from the specified type inside the Unit Of Work class
            // ex: var repository = new GenericRepository<T>(_dbContext) 


            /* End ******************************************************************************************************************/

            #endregion


            #region Order Controller

            /* Start *****************************************************************************************************************/

            // Note : See swagger improvement , using [ProducesResponseType(typeof(X), StatusCodes.X)]
            // Note : See Specification class that we added (Revision on Specification Design Pattern)

            // See OrderToReturnDTO , how the order is returned as a response 

            // Mapping from "Order" to "OrderToReturnDTO" :
            // 1 - string status + [EnumMember] (not Enum OrderStatus) , taken as a string , by default in the DTO as the string value  
            // 2 - DeliveryMethodCost & DeliveryMethod : Mapped from the navigational property DeliveryMethod 
            // 3 - OrderItemDTO Items collection (not OrderItem items collection) : the extra "product" word , (flatten ProductItemOrdered )
            // 4 - Total property gets its value from the derived attribute (as a [NotMapped] read only property or getter method) "GetTotal"
            // 5 - Resolve Picture URL

            // Note : Use [JsonIgnore] Json Ignore data annotation to stop the error of Swagger , above the navigational properties 
            //        or objects from classes inside a class (didn't know how to solve this problem , use this data annotation and it will
            //        also not be ignored in the Json !!! )


            // Next is : we've added class "OrderItemPictureUrlResolver" to resolve the URL returned to be full url of a picture , same we've
            //           done in "ProductPictureUrlResolver"


            // Last : Adding Endpoint for getting all the delivery methods we have .. 

            /* End ******************************************************************************************************************/

            #endregion


            #region Refactor Product Module

            /* Start *****************************************************************************************************************/

            // Now we will refactor Product Controller to work with Product Service , and the Product Service will work with the Unit Of Work ,
            // we've commented the "adding repository service" , from the program class (or ApplicationServicesExtension class)

            // 1 - in project "Core" , Add a new interface in folder "Services.Contracts" => IProductService
            // 2 - in project "Service" , Add class "ProductService" that implements the previous interface (works with Unit Of Work)
            // 3 - Add the services for "ProductService" in the program class (or ApplicationServicesExtension class)
            // 4 - Edit the Product Controller to work with Product Serivce Directly

            /* End ******************************************************************************************************************/

            #endregion


            #region Refactor Order module

            /* Start *****************************************************************************************************************/

            // Any one Uses the order controller must be authorized
            // [AllowAnonymous]            -> It's the default
            // [Authorize]                 -> We will add it

            // if i want the whole controller to be authorized , then add [Authorize] above all the controller , and if there is only one 
            // endpoint that is not authorized then i can add [AllowAnonymous] above this only endpoint

            // Now we will Get all the buyerEmails from the Token , Using the "User" Property inherited ... (discussed before in session 5)
            // var buyerEmail = User.FindFirstValue(ClaimTypes.Email); 
            // User => Gets the claims of the user associated with the executing action 


            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
