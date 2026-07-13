using IdentityWithRazorPages.Data;
using IdentityWithRazorPages.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityWithRazorPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Start making the project 

            /* Start *****************************************************************************************************************/

            // Important : There are some steps that are different from the video , due to working with differenct versions of .Net


            // We will use the Identity (for managing users and accounts and ... ) but with Razor pages this time .
            // we have a package in Razor pages that is already implemented , we can edit this implementation without problems 


            // First make a MVC project , but when choosing the Authentication type -> "Individual Accounts"
            // We will notice that it's a default MVC Project but with new folder "Areas" , it's almost empty ! the files are hidden 
            // to show them : 
            // 1 - edit the app settings "connection string" and update database in the package manager console ... 
            // 2 - in "Areas" folder , Add -> New Scaffolded Item -> Identity -> choose all files + the default DbContext 
            // 
            // Now we will notice that the "Areas" folder contains the cmhtml files + the Behind Code (.cs file)
            // Razor Pages -> MVVM , without controllers 

            // now we can work with the DbContext to change the table names , use a custom model instead of the Identity user (the new
            // model is ApplicationUser) 
            // Note : When changing to "ApplicationUser" we must edit this inside all the files and views and partial views
            //        I edited the register code , login , logout (and added inputs in register) (and added login with email or username)

            /* End ******************************************************************************************************************/

            #endregion

            #region Edit Profile and Data Seeding

            /* Start *****************************************************************************************************************/

            // Now we will allow the user to change his name + add a profile picture
            // Areas -> identity -> Page -> Account -> Manage 

            // see the index code , index view , login partial , ... 


            // Data Seeding : We will make an empty migration and then write code inside the two functions of it 


            /* End ******************************************************************************************************************/

            #endregion



            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser , IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}
