using IKIA.DAL.Presistence.Data;
using Microsoft.EntityFrameworkCore;

namespace IKIA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            #region Adding services for dependency injection for DbContect class 

            /* Start *****************************************************************************************************************/

            // // difficult way (detailed)
            // builder.Services.AddScoped<ApplicationDbcontext>();
            // builder.Services.AddScoped<DbContextOptions<ApplicationDbcontext>>((ServiceProvider) =>
            // {
            //     var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbcontext>();
            //     optionsBuilder.UseSqlServer("");
            //     // Here we will configure the ConnectionString , so we don't need the OnConfiguring function in the ApplicationDbContext
            // 
            //     return optionsBuilder.Options;
            // });

            // instead of writing the last code ... , we can use "AddDbContext" method directly

            builder.Services.AddDbContext<ApplicationDbcontext>(
                // contextLifetime: ServiceLifetime.Scoped,      // the default for them 
                // optionsLifetime: ServiceLifetime.Scoped,      // the default for them 
                optionsAction: (optionsBuilder) =>
                {
                    // optionsBuilder.UseSqlServer("Server=, ; Database = IKIA ; Trusted_Connection = True ; TrustServerCertificate = True ;");


                    // Writing the connection string as we used to is not a good way , connection string is changed from one environment
                    // to another so we must get it from the "appsettings.json" file (for each environment we have an appsettingsfile)..
                    // notice that file , we added a new section "ConnectionStrings" having one Key "DefaultConnection" ...
                    // (advanced : this connection string must be encrypted )
                    // We will talk to the appsettings using the "builder" , it contains services , configurations , Environment , ...

                    optionsBuilder.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);

                    // if the name of the Section is "ConnectionStrings" so directly use "GetConnectionString" method
                    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                }
            );

            /* End ******************************************************************************************************************/

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();                  // Will be discussed later
            }

            // Note : Ordering of adding middlewares is very important and may cause errors and Exceptions

            app.UseHttpsRedirection();          // Redirecting any HTTP request to HTTPS

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();             // not important now 

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
