namespace Regions
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // Local storage in browser and the data it can hold
            // Microservices and Rabbitmq

            /* End ******************************************************************************************************************/

            #endregion


            #region In-Memory Database using Redis

            /* Start *****************************************************************************************************************/

            // Redis : Remote Dictionary Server , In-memory data store used as Caching , vector database , document database ,
            //         streaming Engine , message broker
            // 
            // Redis has built-in replication and different levels of on-disk presistence , and supports complex data structures such as :
            // strings , lists , hashes , sets , JSON
            // The Dictionary key must be string , but the value can be anything of the previous mentioned data structures (better than the
            // local storage , it's a dictionary also and the key is string but the value doesn't support data structures (search))


            // All Redis data resides in Memory , that enables low latency and high throughput data access (better than storing the data in
            // the disk) 

            // To support Replication and presistence , the Redis server takes a snapshot of the data in RAM and puts it in the disk 
            // (that to avoid loosing data if the server is closed [RAM and Cache is Volatile memory] and when the server is opened then the data
            // is restored and not lost)

            // Note : Redis internally is Clustered (having more than one database)

            // Redis is a service same as the SQL Server Service , so we must install it first , but it's not a windows service and not
            // officially supported in windows , so there is a work around to be able to install it : install Redis For Development and
            // follow some instructions documented in the official website , this way works only for Windows 11 and Windows 10 version 
            // 2004 or higher (doesn't work in my case) , so there is another way to work with the version on Github that is developed
            // by some developers to solve the problem of Windows 10 Versions (google search on "Redis For Windows Github" by tporadowski)
            // Link : https://github.com/tporadowski/redis/releases
            // Note : Provided in the Drive and Videos folder , Open redis-server.exe (must be opened)

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with Basket Module

            /* Start *****************************************************************************************************************/

            // The basket module has 2 entities : 
            // 1 - CustomerBasket
            // 2 - BasketItem

            // so in project "Core" in entities folder , add a folder for the module and inside it add the two entities

            // Important note : The entities inside Basket module are not BaseEntity (cannot inherit from BaseEntity Class) because
            //                  these entities will not interact with the ApplicationDbContext .. we will have another DbContext for
            //                  this module

            // After making the entities , we will not make DbSets and migrations as we did in the SQL Server Database 

            // Now we will make the Basket Repository (and we cannot use the Generic Repo used in the Product module because it interacts
            // with the ApplicationDbContext that uses the SQL Server database) 

            // First we will make a small change in the Repository Project (make two folders , one for the Generic Repository and the other
            // for the Basket Repository .. Don't miss changing the namespaces to avoid errors .... )


            // Before implementing the repository , install the Redis package "StackExchange.Redis" in Repository project to be able to
            // interact with Redis (don't miss allowing the dependency injection for Redis service)
            // Basket Repository Implemented, check implementation (IBasketRepository => Core Project, BasketRepository => Repository Project)


            // Implement the Controller ..  


            // Note : we can use a tool called "Redily" , provides a UI for Redis (Not an Official tool) 

            // finally , in this session we will validate on the customer basket (item price > 0 and quantity > 0 and Required Fields , more
            // validations in the next sessions).... 
            // we will achieve this by doing a DTO for customer Basket and Basket Item .. and Add data annotations for the properties there
            // (The DTO is just for validations) 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
