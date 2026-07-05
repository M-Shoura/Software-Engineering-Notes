using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWindConsolApp.Entities
{
    public partial class Product
    {
        public override string ToString()
        {
            return $"{ProductID} :: {ProductName} :: {UnitPrice} :: {QuantityPerUnit} :: {Supplier?.CompanyName??"NA"} :: {Category?.CategoryName??"NA"}";
        }
    }
}
