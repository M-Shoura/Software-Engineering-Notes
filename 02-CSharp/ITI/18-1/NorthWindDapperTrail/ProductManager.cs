using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace NorthWindDapperTrail
{
    public class ProductManager : IManager<Product>
    {
        DbConnection CN = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;Encrypt=false");
        public bool Add(Product item)
        {
            try
            {
                return CN.Execute("""
                    INSERT INTO Products
                    (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                    VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)
                    """, item) > 0;

                // Note : here we sent the object "item" as a parameter because the names of the properties in Product class is the same 
                //        as the names of columns of product table , so if the names were not same then we might send them one by one , 
                //        ex: item.ProductName , item.Price , .... 
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long ID)
        {
            return CN.Execute("DeleteProductById", new { Id = ID}, commandType: System.Data.CommandType.StoredProcedure) > 0;
        }

        public List<Product> GetAll()
        {
            return CN.Query<Product>("Select * from Products").AsList();
        }

        public Product GetById(long Id)
        {
            return CN.QueryFirstOrDefault<Product>("Select * from Products where ProductID = @prdId", new { prdId = Id }) ?? new Product();
        }

        public bool Update(Product item)
        {
            return CN.Execute("PrdUpdateCommand", item, commandType: System.Data.CommandType.StoredProcedure)>0;

            // Note : if the product class is not "SAME" as the product table row , ex: having a navigational property here that is not 
            //        in the Table , then we must send the item as each property as a parameter not like in the last step we sent the whole
            //        product object "item"
        }
    }
}
