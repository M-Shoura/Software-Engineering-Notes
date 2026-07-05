using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NorthwindConsoleApp.Entities;

namespace NorthwindConsoleApp.Context;

public partial class NorthwindContext : DbContext
{
    public NorthwindContext()
    {
    }

    public NorthwindContext(DbContextOptions<NorthwindContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data source=.;Initial catalog=Northwind;integrated security=true;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0, "DF_Products_ReorderLevel");
            entity.Property(e => e.UnitPrice).HasDefaultValue(0m, "DF_Products_UnitPrice");
            entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0, "DF_Products_UnitsInStock");
            entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0, "DF_Products_UnitsOnOrder");

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products).HasConstraintName("FK_Products_Suppliers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
