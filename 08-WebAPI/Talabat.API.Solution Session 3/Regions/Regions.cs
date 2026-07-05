namespace Regions
{
    internal class Regions
    {
        static void Main(string[] args)
        {
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // more about IEnumerable VS IReadOnlyList
            // Ofset and Fetch in SQL

            /* End ******************************************************************************************************************/

            #endregion


            #region Cleaning Program Class

            /* Start *****************************************************************************************************************/

            // We will make Extension Methods ... 
            // in API project , create folder "Extensions" that will contain the static classes for extension methods .. 
            // See the classes "ApplicationServicesExtension" , "SwaggerServicesExtension"

            /* End ******************************************************************************************************************/

            #endregion


            #region IEnumerable VS IReadOnlyList

            /* Start *****************************************************************************************************************/

            // Incase we want to enumerate on the data , ex: in MVC project and enumerating on all the employees to show them .. then 
            // the IEnumerable will be better 
            // but if we want only to return the data as we do here in API project , return only without any change .. then using 
            // IReadOnlyList is better because it's a Readable random access collection (used better in caching and in-memory collections)

            // Note : IEnumerable is more generic and can be used in any case 

            // So we will use "IReadOnlyList" instead of "IEnumerable" in the Generic Repository and in the Product Controller

            /* End ******************************************************************************************************************/

            #endregion


            #region Sorting & Filteration - Continue Specification Design Pattern

            /* Start *****************************************************************************************************************/

            // By default , the products are returned with the same ordering that is in the Database , sorted by the PK (id) 
            // What if we want to order by another column 
            // Now we will order by (Name asc) , or (price asc desc) , with one column of ordering (we will not use ThenBy , ThenByDesc)
            // only OrderBy and OrderByDesc

            // We will use Quey Parameters in the URL in the Query String 
            // in the Product Controller , the GetProducts will take parameter "string sort"
            // add the OrderBy and OrderByDesc in the ISpecification and BaseSpecifications


            /* End ******************************************************************************************************************/

            #endregion


            #region Pagination and Search - Continue Specification Design Pattern

            /* Start *****************************************************************************************************************/

            // When consuming the endpoint , send two important things : PageSize and PageIndex , then we can know Skip and Take ...
            // The endpoint will take more two parameters pageSize and pageIndex , but now the endpoint takes 5 parameters :
            // sort , brandId , categoryId , pageIndex , pageSize ... that's bad and not "Clean Code" !
            // So we will make a new class "ProductSpecParams" that have the 5 properties and the parameter of the endpoint will be an
            // object from this class (Don't miss [FromQuery] to bind the model data from Query String)
            // See the Added Implementation 


            // Every endpoint works with Pagination must follow the standard Response : 
            // object having 4 properties : 
            // 1 - Page Index
            // 2 - Page Size
            // 3 - Count (of all the object following the criteria)
            // 4 - Data (response data objects .. )

            // so in the API project in the Helper class , add a class "Pagination" that has the standart response structure (discussed above)

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}
