using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Repository.Generic_Repository.Data.Configurations
{
    internal class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Shipping Address is mapped with Owner (Order) [1-1] Total participation from 2 sides
            builder.OwnsOne(o => o.ShippingAddress, shippingAddress => shippingAddress.WithOwner());


            // Status stored in the database as strings , and when retrieving converted to the Enum type again
            // Note : Don't miss using data annotation [EnumMember(Value=XXXXXX)]
            builder.Property(o => o.Status)
                .HasConversion (
                    x => x.ToString(),                                        // When saved in the database
                    X => (OrderStatus)Enum.Parse(typeof(OrderStatus), X)      // When retrieved from the database 
                );


            // Delivery Method relationship with Order .. Order MUST have a delivery method , a delivery Method can have man orders and 
            // also a delivery method can have no orders ... [1-m] partial participation from many side

            // Commented because this is done by default in our case .. we didn't put an ICollection<X> in the many side , so it will be 
            // by default the many side as we put a navigational property one in the one side .......
            // builder.HasOne(o => o.DeliveryMethod)
            //     .WithMany();


            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");


            builder.HasOne(o => o.DeliveryMethod).WithMany()
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
