using Microsoft.EntityFrameworkCore;
using MyHospitalApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyHospitalApp.Context
{
    public class HospitalContext : DbContext  
    {
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=HospitalDB;Integrated Security=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
