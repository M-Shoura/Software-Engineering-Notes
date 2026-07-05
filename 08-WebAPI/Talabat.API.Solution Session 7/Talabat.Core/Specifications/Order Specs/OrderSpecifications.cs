using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.Specifications.Order_Specs
{
    public class OrderSpecifications : BaseSpecifications<Order>
    {
        public OrderSpecifications(string buyerEmail) : base(O=>O.BuyerEmail == buyerEmail)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);   
            // in our case , it's important to include the items , as we will not get an order object without it's items .. this depends on
            // the business case .. if we work with employee and department then when getting a department maybe it's not important to
            // get all the employees inside this department 

            // so in our case we will load items "Eager Loading"


            AddOrderByDesc(O=>O.OrderDate);
            // by default order by the date descending
        }

        public OrderSpecifications(int orderId , string buyerEmail) : base(O=>O.Id == orderId && O.BuyerEmail == buyerEmail)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);
        }
    }
}
