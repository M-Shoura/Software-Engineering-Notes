namespace Regions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // we will work with Code First , start always with the Model and your entities

            // when making the DbContext class , download the three packages : 
            // - Microsoft.EntityFrameworkCore.Tools            // for commands , add migration , ..... 
            // - Microsoft.EntityFrameworkCore.Design           // recently it's a MUST to download it manually , for auto-generating and scaffolding and ... 
            // - Microsoft.EntityFrameworkCore.SqlServer        // or our SQL Provider

            // remember and self study : relationship rules (onDelete : ... OnUpdate : ...)

            // Generating controllers : 
            // right click -> Add controller with read/write actions

            // Generating view for each action : 
            // for each action generate view -> Add view -> Razor View -> specify the templete and other info wanted ... 


            // _ViewImport : have all the usings that are used in the views , so it's not in one place instead of putting it in more than one view 


            // Note : See how we show countries when editing city (select from List of countries with the country name , not the country ID), see all other
            //        views and the controller also.


            // ---------------------------------------------------------------------------------------------------------------------------------------------

            // Part 2 : 

            // Tag Helpers : 

            // HTML Helper makes sending data easier (no slashes / ) , each parameter is sent lonely , and using functions is maybe easier than using HTML
            // tags (for backend Devs) 

            // Disadvantages :
            // - Not all html tags have HTML Helpers (ex: button , table , ... )
            // - some HTML helpers doesn't have the same name of the HTML Tags (ex: ActionLink for <a> , .. )
            // - we must send parameters with the same order that the function overload wants
            // - using anonymous object is a bad thing (especially with styling and bootstrap)


            // Tag helpers : 
            // - works with only Strongly typed views (Model)
            // - using default HTML Tags 
            // - HTML Tag name is the same , giving classes is the same 
            // - default HTML Tag + "asp-"  ===> This is now a Tag Helper ! 
            // - Can use any ordering ! 
            // - To give a parameter : asp-route-ParameterName="ParameterValue"

            // ex: <a asp-controller="Home" asp-action="Calculate" asp-route-x=4 asp-route-y=9 class="btn btn-info"  >  Click Me  </a>


            // three ways : 
            // <a href="/Home/Calculate/?x=4&y=9" class="btn btn-primary"> Calc_Plain_HTML_Link</a>
            // @Html.ActionLink("Calc_Plain_HTML_Helper", "Calculate" , "Home", new {x=4, y=9}, new {@class="btn btn-primary"})
            // <a asp-controller="Home" asp-action="Calculate" asp-route-x="4" asp-route-y="9" class="btn btn-primary">Calc_Plain_Tag_Helper</a>

            // all them when rendered (can be seen in inspect in the browser) are the same as the normal default plain HTML Tags


            // Tag helpers are good because : 
            // - we use the plain HTML Tags
            // - for each html tag , only valid Tag helper will be shown (ex: for select , the asp-for and asp-items only will be shown , but for <a> there
            //   are other tag helpers as asp-controller , asp-action , .... )
            // - it's used with validations (next session)


            // MUST see from 30:00 to 50:00


            // ----------------------------------------------------------------------------------------------------------------------------------------------


            // Areas : 

            // What is Schema in SQL Server ? More organized way for my system !
            // so Schemas in SQL Server is the same as MVC Areas here 

            // so the areas are used for organizing the controllers (in large applications , we may have tens of controllers) ... so we can organize them to be 
            // as areas , each area acts like a small MVC application that has it's controllers and actions and views . 

            // Note : some controllers and actions and views are General (not for a specific area) , also we could have model for each area (database for each
            //        area ) or we can have one model (database) for all areas but for each area it has it's controller and views

            // Note : Each area must have a Route for it , as accessing areas with the same route templete for the MVC app will not work (as areas treated as
            //        small MVC apps ! ) ... So for each area it must have at least one route templete 
            //        ex: baseURL/AreaName/ControllerName/{ActionName}


            // To add a new Area => Right click on the project => Add => New Scaffolded Item => MVC Area 
            // OR if we have already areas in the application => right click on the areas folder => Add => Area

            // to add the Route templete for each area : 



            // Note : we notice that the layout is not applied on the views in the Areas , that's because the areas are treated as Small MVC apps , each running
            //        with it's layouts and views and ... so to make views take the layout for the default MVC app, then in each view inside the areas add
            //        the layout = ~/Views/shared/_Layout.cshtml     ... this makes the view applies the layout , bit this is added manually for each view , to 
            //        make this more easier make a _ViewStart for each area that applies the Layout on all views inside this area

            // To add a view start : inside the Views folder => right click => Add New Item => Razor View Start


            // Note : Areas routes also are added to the routing table.
            // Note : Ordering is important , all areas must be in the first ... 

            /*
            
            // Note : MapAreaControllerRoute , not MapControllerRoute ... 

            app.MapAreaControllerRoute(
                name:"area1", 
                areaName:"Students",
                pattern:"Students/{controller=std}/{action=index}/{id?}"
                );
            
            app.MapAreaControllerRoute(
                name: "area2",
                areaName: "Teachers",
                pattern: "Teachers/{controller=tchr}/{action=index}/{id?}"
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
             */
        }
    }
}
