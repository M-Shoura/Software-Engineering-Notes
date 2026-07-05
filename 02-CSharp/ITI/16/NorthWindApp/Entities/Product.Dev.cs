using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWindApp.Entities
{
    public  partial class Product
    {
        public override string ToString()
        {
            return $"{ProductId} :: {ProductName} :: {UnitPrice} :: {QuantityPerUnit} :: {Supplier?.CompanyName ?? "NA"} :: {Category?.CategoryName ?? "NA"}";
        }
    }
}
