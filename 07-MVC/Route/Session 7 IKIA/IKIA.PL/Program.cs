using IKIA.BLL.Common.Services.Attachments;
using IKIA.BLL.Services.Departments;
using IKIA.BLL.Services.Employees;
using IKIA.DAL.Presistence.Data;
using IKIA.DAL.Presistence.Repositories.Departments;
using IKIA.DAL.Presistence.Repositories.Employees;
using IKIA.DAL.Presistence.UnitOfWork;
using IKIA.PL.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IKIA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<ApplicationDbcontext>(optionsBuilder =>
            {
                optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            

            
            // Now we will comment them because we will use the Unit Of Work , no requesting objects from the CLR of type Repositories again
            // builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            // builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            
            
            builder.Services.AddAutoMapper(m=>m.AddProfile(new MappingProfile()));
            // or
            // builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            builder.Services.AddTransient<IAttachmentService, AttachmentService>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            // app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
