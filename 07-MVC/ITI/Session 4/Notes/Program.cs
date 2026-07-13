namespace Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // To send parameters when using RedirectToAction (anonymous object) : RedirectToAction("GetAllCars", new {id=1, name="shoura"});            


            // Important and Self study : ASP.NET model binder is the part of .Net which see the names of inputs in forms and match them in the next 3 ways : 
            // Ways for sending data from the view to action controller (Model Binding) :
            // Note : way 2 and 3 are the most recommended.
            //
            // 1 - public IActionResult Edit(int id, string name) { ... }
            //       - works with method = Get (from Query string) and method = Post
            //       - not case sensitive , parameters letters and name attribute with tags in HTML code
            //       - if we have input in HTML code that doesn't have same name as parameter , then we skip this input and it's data is Lost 
            //       - if we have a parameter in action that doesn't have a corresponding input name in HTML , then it takes the default value for that type.  
            //
            // 2 - public IActionResult Edit(IFormCollection collection) { ... }
            //       - Works with method = Post ONLY
            //       - Collection of input names used in the form , key value pair , key is string and value is of type "StringValues" search and self study.
            //       - ex: int id = int.Parse(collection["id"]);
            //       - Is it case sensitive ? search !
            //
            // 3 - public IActionResult Edit(Employee emp) { ... }
            //       - Works with method = Post ONLY
            //       - Is it case sensitive ? search !
            //       - if we have input in HTML code that doesn't have same name as any object pattribute , then we skip this input and it's data is Lost 
            //       - if we have object pattribute that doesn't have a corresponding input name in HTML , then it takes the default value for that type.  


            // in case 3 , what if i want to take only 3 inputs from the submitted data from the form ? if the form contains many inputs and i don't want 
            // them all them this will save some time for me ! then use "[Bind(Include:"name1, name2")]" and choose the input names you want only 
            // NOTE : CASE SENSITIVE , SHOULD BE SAME AS CLASS ATTRIBUTES OR PROPERTIES.
            // - Ex: 
            // public IActionResult Edit( [Bind(Include:"id, name")] Employee emp) { ... }
            // - So now the .NET model binder will see only the two selected , and dismiss others (data will be lost), Why doing this ? used in future cases !
            // - if object has other attributes then they will have default values for their types.


            // -------------------------------------------------------------------------------------

            // HTTP verb : 

            // now inside the controller , in case of "Editing" , we will have 2 actions , one for returning the Edit View and other for Edit logic , so why
            // we have actions with different names while having "Overloading" ? 
            // ex: 
            // public IActionResult UpdateCar(int id) { ... }
            // public IActionResult UpdateCarLogic(int id, string manfacture, string model, string color) { ... }
            // 
            // so both of them can be named with "Edit" , as they have different parameters BUT THIS WILL NOT WORK WITH MVC PATTERN 
            // we must differentiate between them using the HTTP verbs attributes (over action methods) , the default HTTP verb for all actions => [HttpGet]
            // ex: 
            // [HttpGet]
            // public IActionResult UpdateCar(int id) { ... }
            // 
            // [HttpPost]
            // public IActionResult UpdateCarLogic(int id, string manfacture, string model, string color) { ... }
            // - This is the version we go to after Posting the form data , so it's HttpPost


            // another advantage of using HTTP verbs : 
            // if i inspected the frontend and saw the form and knew the input fields data and form (method, action) ... this is not secure at all and we can 
            // write the action and query string directly in the URL to skip the frontend validation and never go to the view that takes data from user 

            // ex: http://localhost:5500/Employee/EditSave/?name=any&Id=2           // so here we changed data without goint to frontend validation 

            // so we can use HTTP verbs here , and make an obstacle that cannot be achieved in a way other that a "Form Submit" ... so if we added [HttpPost]
            // above an action method then we now can reach this action in one way => "form submit" with method = Post


            // -------------------------------------------------------------------------------------------------------------------------------------------


            // Ways for sending data from the action controller to the view : 
            // - ViewData                  // Discussed before , NOT a strongly typed view , we don't know the type of the data we will work with 
            // - ViewBag                   // .... .... ..... .... .... ..... .... .... ..... .... .... ..... .... .... ......... .... ..... .... 
            // - Model Property            // Discussed Now , can be strongly typed view if we specified the type by @model 

            // ALL OF THEM PUT DATA IN THE ViewDataDictionary
            // can we access things in the Model by ViewData or ViewBag ? Search and self study

            // Model Property: 
            // - Most recommended way 
            // - It's a property for every view
            // - in the auto-generated code , this is the way used 
            // - we can send data through Model property => return View(DataHere);   // this is the overload that takes the model that will be rendered by view
            // - Note : it's a Capital case M , not small case m ...  


            // where is the C# code that we write in Razor page written ( @ or @{ .. } )? 
            // .NET creates a class called "ControllerName_ActionName_View" that has the C# Code we write in Views 
            // Any VIEW inherits from "webViewPage" or the dynamic version "webViewPage<T:dynamic>" 
            // this class has "dynamic Model;" it's dynamic because we don't know the type of the object that will be sent from the action
            // ex: return View(EmployeeList);          
            //     inside Razor Page : 
            //     foreach(var x in (List<Employee>) Model)              // or we can skip casting , as it's dynamic

            // how to tell the application that we are working with a specific type ? 
            // @model List<Employee> 
            //
            // Note : this is small case m , used to tell the view that the Model property is not dynamic but a specific type


            // Disadvantages of Model property : 
            // we can only send one resource , what if we want to send more than one thing ? not valid (WILL BE SOLVED LATER ...)
            // So we can send the main resource in the Model and if we want to send any other thing then use "ViewBag" or "ViewData"


            // so to summarize : 
            // 1 - send the data from the controller , return View(Data); , ex: return View(empList.FirstOrDefault(x=>x.id==1));
            // 2 - specify the type of the data in the first lines of the View , @model DataType , ex: @model Employee
            // 3 - use the Model directly , ex: <h1> Model.Id </h1>


            // -------------------------------------------------------------------------------------------------------------------------------------------

            // HTML Helpers : Video PART 2

            // MUST SEE SLIDES

            // We have .Net Helpers , HTML Helpers , Tag Helpers ... But we will not study .Net Helpers because they are not often used today ! but 
            // HTML Helpers and Tag Helpers are used and also used in the auto-generated code


            // Helpers are introducted for people who are coming from a backend development background and wanting to make frontend ... it's here to make HTML easier


            // Most (NOT ALL, ex: button) HTML Tags have extension methods , that are in class called HTMLHelper that has methods with the same name of the HTML Tags , so if we
            // want to use the functions instead of HTML Tags then it's OK and the Tags will be rendered to HTML Tags automatically

            // how to use ? 
            // @HtmlHelper.FunctionName(Parameters .... )

            // Note : We can make our own HTML Helpers (inline HTML Helpers) , @functions{private void myFun() { // LOGIC HERE } }

            // HTML Helpers are categorized to more than one category , most known => (Built-in and Inline): 
            // - Built-in HTML Helpers : 
            //     - Standart HTML Helper : has the same name of HTML Tags 
            //     - Strongly typed HTML Helper : used ONLY with strongly typed views "Model" , has same name of HTML Tags but with "for" in last of it's name
            //                                    ex: DropDownListFor() , CheckBoxFor() , ..  Note : We use Labda expressions with it.
            //     - Templeted HTML Helper : used ONLY with strongly typed views "Model" , the most recommended to be used as they are intelligent , 
            //                               ex: EditorFor() , DisplayFor() , DisplayNameFor()
            // - Inline HTML Helper : our own functions that we will make.
            // - ...
            // - ...


            // <label> Name </label>
            // @Html.Label("Name")]
            // @Html.LabelFor(model => model.Name)


            // <input type="text" name="Salary">
            // @Html.textBox("Salary","text");
            // @Html.textBoxFor(m=>model.Salary, new{@class="btn btn-info"});


            // Templete HTML helper : 
            // DisplayNameFor(m=>m.Salary) => shows the title or header
            // DisplayFor(m=>m.Salary)     => READ ONLY , VALUES 
            // EditorFor(m=>m.Salary)      => Can be changed (used with edit mostly) , VALUES , input type = "BASED ON THE PROPERTY TYPE"

            // see Views in the assignment solution .... 

            // Note : the link or <a> is different here , it's called "ActionLink" that takes the word that we will click on , the action , the controller , the parameters that
            //        we want to send (using anonymous object sent in parameter of function overload "rootValues") , and the bootstrap class or class (using anonymous object sent
            //        in parameter of function overload "htmlAttribute" and write class with @ , ex: @class="btn btn-danger")

            // Note : form also is different here , see slides

            // Note : the name and Id attributes are the same 

            // Note : We can find the same function as a standart HTML Helper and Strongly typed HTML Helper , if the view is Strongly typed then it's better to use the 
            //        Strongly typed HTML Helper but the standart HTML Helper will work also !   



            // What about the second Category ? 

            // Inline HTML Helpers : what if i want more than the built-in html helpers ? 
            // make your own using Inline HTML Helper 

            // - It's a function that contains HTML tags
            // - It can be used only within the view that it is created in.



            // ---------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Auto Generation : 

            // When wanting to auto generate Controller :
            // when creating a new controller -> MVC Controller with read/write actions -> Now complete the controller ! 

            // When wanting to auto generate Views : 
            // right click on views or inside the action method -> Add View -> choose the Templete (List-> get all , or Edit , or create , ...) -> choose the
            // model or class that we will work with.

            // Note : for auto generating views , we must use the Model Property to send data from the controller to views , other wise it will not work 

        }
    }
}
