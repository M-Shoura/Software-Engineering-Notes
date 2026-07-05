using Microsoft.AspNetCore.Routing.Constraints;

namespace MVC___Session_2
{
	public class Program
	{
		public static void Main(string[] args)
		{

			var builder = WebApplication.CreateBuilder(args);

			// builder.Services.AddTransient<>() or AddSingleton<>() AddScoped<>       // to add a service 

			// builder.Services.AddControllers();
			// builder.Services.AddControllersWithViews();
			// builder.Services.AddRazorPages();
			builder.Services.AddMvc();


			var app = builder.Build();


            // Note : Ordering of adding middlewares is very important and may cause errors and Exceptions

            app.UseStaticFiles();      // enable static files serving (files must be in wwwroot)

            if (app.Environment.IsDevelopment())
				app.UseDeveloperExceptionPage();
            else
				app.UseStatusCodePagesWithReExecute("/Home/Error");


            // app.MapGet("/", () => "Hello World!");
            // app.MapGet("/XX{id}", () => "Hello Wolrlllld!");
			// app.MapGet("/Shoura", async context =>
			// {
			// 	context.Response.StatusCode = 501;
			// 	await context.Response.WriteAsync("Hello Shoura");
			// });

			// Note : Here we didn't specify the verb , ex: get , post , put , delete ... as we did in the minimal APIs above
			app.MapControllerRoute(
				name: "default",
				pattern /*URL Path*/: "{controller=Home}/{action=Index}/{id:int?}/{name:alpha?}"
			);

			app.Run();
		}
	}
}
