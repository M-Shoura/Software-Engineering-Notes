using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public class DeliveryMethod : BaseEntity
    {
        // The EFCore (When making migration) wants a accessible empty parameterless constructor for classes that will be mapped to table 
        // or classes used inside classed mapped to tables so we will make empty constructors for all the classes we've made in order module
        // These Ctors can be private also , to have only by the efcore when generating tables and forcing users to use the other ctors
        public DeliveryMethod()
        {

        }
        public DeliveryMethod(string shortName, string description, decimal cost, string deliveryTime)
        {
            ShortName = shortName;
            Description = description;
            Cost = cost;
            DeliveryTime = deliveryTime;
        }

        public string ShortName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string DeliveryTime { get; set; }
    }
}
