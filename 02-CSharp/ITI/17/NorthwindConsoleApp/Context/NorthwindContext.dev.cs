using Microsoft.EntityFrameworkCore;
using NorthwindConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindConsoleApp.Context
{
    public partial class NorthwindContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>().HasQueryFilter(p => p.Discontinued == false);
            // Note : this makes problems when execution FromSql($"spName") ... .
        }
    }
}
