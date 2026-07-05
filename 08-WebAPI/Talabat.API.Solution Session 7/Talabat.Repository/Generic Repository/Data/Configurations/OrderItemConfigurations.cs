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
    internal class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Product Item Ordered is mapped with Owner (OrderItem) [1-1] Total participation from 2 sides
            builder.OwnsOne(o => o.Product, product => product.WithOwner());


            builder.Property(o => o.Price).HasColumnType("decimal(18,2)");
        }
    }
}
