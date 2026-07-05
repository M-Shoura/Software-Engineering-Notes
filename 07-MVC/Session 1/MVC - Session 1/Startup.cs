using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC___Session_1
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{


			// we here add the services : 
			// 1 - AddTransient<Class>();        // Every time we want an object the CLR creates a new one
			// 2 - AddScoped<Class>();           // CLR Creates an object of classes we use but one object per request (Most used)
			// 3 - AddSingleton<Class>();        // CLR Creates one object for the All Session 


			// Here also we can configure the project that it will work with MVC , Razor Pages , APIs , or all of them !!
			// That is done by allowing the dependency injection for the built-in services that the project needs to work as MVC Project or 
			// a API Project , or a Razor Pages project , or all of them .. we don't allow these services manually , this is done by using one 
			// of the methods : 

			services.AddControllers();   // Allows dependency injection for all the built-in services that the project uses to work as API project

			services.AddControllersWithViews();  // Allows dependency injection for all the built-in services that the project uses to work as MVC
												 // project or an API project also (because APIs => MC [without views])

			services.AddRazorPages(); // Allows dependency injection for all the built-in services that the project uses to work as Razor Pages project

			services.AddMvc();     // Allows dependency injection for all the built-in services in the ASP.NET Core , so all types of projects will work

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
            // Here we configure the middlewares/pipelines that the http request will go through it  


            // Note : Ordering of adding middlewares is very important and may cause errors and Exceptions


            if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>                           // we here write the Routes
			{
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Hello World!");
				});
				endpoints.MapGet("/Shoura", async context =>             // a new route here , URL/Shoura ... 
				{
					await context.Response.WriteAsync("Hello Shoura!");
				});
			});
		}
		
		// These two methods are called by the runtime (CLR) 
		// ConfigureServices adds the service to the container , the container is of type IServiceCollection ... it's all about Dependency injection 
		// so the object of type IServiceCollection is the services container that we will put services we want it to work with the dependency injection
		// in this container
	}
}
