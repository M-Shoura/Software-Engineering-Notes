using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Recieved")]
        PaymentRecieved,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed


        // Note : EnumMember data annotation is used to store the Enum value in the database as the string defined above it , not the 
        //        int value 0 or 1 or .... 
    }
}
