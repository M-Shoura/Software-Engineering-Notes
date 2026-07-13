namespace Regions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Data Annotations : 

            // NOTE : SEE SLIDES

            // Data Annotations are nothing but certain validations that we put in our models to validate the input from the user. 
            // these validations are applied when the user enters an input in the form

            // data annotations are found in two namepsaces : 
            // - System.ComponentModel.DataAnnotations.Schema;
            // - System.ComponentModel.DataAnnotations;

            // Note : We can make our own data annotations , as any data annotation is a class that inherits from class called "ValidationAttribute" that has a
            //        function called "IsValid"

            // Note : we have a default error message for data annotations that has error message but we didn't enter it 

            // MUST SEE Classes "Student" and "Department"
            // ex: 
            //
            // [Display(Name ="StudentName")] 
            // public string Name { get; set; }
            // - remember DisplayNameFor() ? 
            // - the property in C# is called Name , the column name in DB is called Name , but when displaying it in the frontend it's "StudentName"
            //
            // [DataType(DataType.Password)]
            // public string Password { get; set; }
            // - DataType. ... enum that has many used datatypes , ex: Password (*******) , or currency ($) , or email (@ and .) , or credit card 


            // how to use the Enum (see create student view), we used HTML Tag helper "GetEnumSelectList<EnumName>()"for getting valid Enum values and show them
            // inside a select list
            //   ex: <select asp-for="Gender" asp-items="@Html.GetEnumSelectList<Gender>()" class="form-control"></select>


            // Note : We must tell where to show errors when adding data that is not valid , not valid due to the restrictions that we added using the 
            //        data annotations we knew today. we can add "HTML Helpers" or "Tag Helpers" in views to show these errors. 
            // SEE CREATE STUDENT VIEW , we used the two ways there ! 

            // 1 - using HTML Helper : 
            // @Html.ValidationMessageFor(x=>x.Name, "", new{@class="text-danger"}) 
            // - Means see any error message attached to this input and show it here with this style

            // 2 - using Tag Helper : USE Span
            // - <span asp-validation-for="Name" class="text-danger"></span>
            // - Note : the span doesn't have a tag helper other than "asp-validation-for"



            // Note : we must make the validation client side also (because the default is server side) , so when making wrong input then we must not sumbit
            //        the data to the server , we must stop them in the client side to minimize server using in cases that will 100% fail (wrong input data)
            //
            // to make this :
            // 1 - Use HTML Helpers or Tag Helpers , because they are smart tags that read the data annotations on the model and encode them
            //     inside the metadata in input HTML Tags in the actual frontend (data-val- ... ) so now the validation is done in the client side (browser)
            //     and we can see it when "inspect" in the browser, now the JQuery validations can work. So the server side validation is ALREADY APPLIED  , 
            //     but we use HTML Helpers or Tag Helpers for frontend validations
            //     ex: when inspect : 
            //           data-val="true"    => we may have client-side validation
            //           data-val-maxlength-max="30"                          => this is the data annotation attribute max length value in the model (class) 
            //           data-val-maxlength="Too Long name , must be <30"     => this is the error message for exceeding the string max length 
            //        
            //
            // 2 - Put the libraries that read the annotations and applies it in the client side (JQuery Libraries) , they are three libraries : 
            //      - jquery
            //      - jquery-validate : does the validation in the cliend side
            //      - jquery-validate-unobtrusive (data-val- ...) : this is the bridge between the encoded code (helpers) and the JQuery-validate library , so 
            //                                                      it understands the encoded data-val-.... 
            //     Then use them inside your views with the same ordering (only views that we want ... ) (~ means from the wwwroot folder) 
            //     or when adding the view in the first step , check "Reference Script libraries" and they will be added automatically
            //       <script src="~/lib/jquery/dist/jquery.min.js"></script>
            //       <script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
            //       <script src="~/lib/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js" ></ script >

            // Add them inside each view or add then inside the layout that is applied to all the views that you need the validation in , or put them inside a 
            // partial view and Render that section inside the views we want to validate in (same as done by the auto generated code of VS with the file called
            // "_ValidationScriptsPartial.cshtml" that is in the shared folder (after generating views and checking "Reference Script libraries"))

            // Note : the libraries are installed because we used a MVC ready project

            // So now the validations work client side (when writing right data then the span is hidden automatically in the view) , putting many validation 
            // layers in the application is right 


            // Remember : the HTML Helper (EditorFor) , and Tag Helper (input) are smart because they allow me to ender values based on the type (for int we
            //            have a numeric values) , also based on the Data annotations on that input (ex: Datatype(Datatype.Password) will change the string
            //            default text box to make password **** in the text box)

            // ---------------------------------------------------------------------------------------------------------------------------------------------


            // Part 2 : 

            // Validation Summary : Showing all errors in one place , it has a HTML Helper and also a Tag helper. It's used with Div 

            // Tag Helpers :  
            // <div asp-validation-summary="all" class="text-danger"> </div>

            // HTML Helpers : 
            // @Html.ValidationSummary(true,"",new {@class="text-danger"})

            // values that it can take : (Will be clear when reading the next region .. )
            // - all              => all errors from the three error providers (data annotations, Model Binder, manually in model state)     
            // - none             => don't shown any errors from these three error providers
            // - ModelOnly        => Don't show from data annotations , but show from the other two error providers (Model Binder, manually in model state)


            // Note : Validation Summary works only SERVER SIDE , so when adding a valid input it also doesn't change , we must submit first and then
            //        the error list will be refreshed (can work client side but with a work around that is not discussed now .. )


            // ------------------------------------------------------------------------------------------------------------------------------------------------


            // Model State : 

            // now we will work with Employee class , Employee List class , and the views for the Employee

            // - ModelState : a property of controller that is used for validating form in server side, using ModelState.IsValid. It's a collection of
            //                “key and value” pairs of inputs that was submitted to the server during post (keys => inputs with names in the form,
            //                values => the given value (attempted value) and the error collection of this input). It also contains a collection of error 
            //                messages for each value submitted.
            // - Anytime you have binding happening, ModelState will contain information about what happened during that model binding.
            // - The default model binder will add some errors for basic type conversion issues(for example, passing non number for something which is "int")

            // ex: if we have an input with name = "Name" , we gave it value "tt" 
            //     if we have an input with name = "Age" , we gave it value "abc"
            //     if we have an input with name = "Salary" , we gave it value "1000" 

            // then the collection : 
            // Key       Values (value & error list)        
            // Name        (tt) & (min length is 3)                            error count = 1
            // Age         (abc) & (conversion failed abc => int Age > 18)     error count = 2 (one from model binder "cannot bind") , other from data annotations
            // Salary      (1000)                                              error count = 0

            // so Name and Age are "Invalid" , but Salary is "Valid"                       ModelState.IsValid = false (3 errors)


            // What is the model binder ? takes the input from the input fields and tries to bind these values in the object or parameters of the action 
            // of the form (the place that we go to after submitting the form)


            // The Recommendation : Don't submit anything to the DB before checking the ModelState.IsValid = True;


            // From where we know the errors ? 
            // 1 - Data Annotation
            // 2 - Model Binder
            // 3 - Errors added by the developers (if conditions , then add error in the model state) 
            //     ex: if(string.IsNullOrEmpty(emp.name))
            //               ModelState.AddModelError("Name","You must enter a name");       
            //     so we give it the input that we want to add the error to , and the error message that will be shown
            //     NOTE : SEE EMPLOYEE CONTROLLER


            // ------------------------------------------------------------------------------------------------------------------------------------------------


            // How to make a custom Data Annotation ? 
            // See class "MinAgeValidation" that is used on the Employee model and "UniqueEmailValidation" that is used on the Student model ....
            // - Inherit from "ValidationAttribute" class 
            // - override the IsValid function (we have 2 overloads that can be overriden)
            //     - see UniqueEmailValidation and MinAgeValidation classes to see the two implementations ... one function return bool and the other return
            //       ValidationResult (class to add Errors in if exists and also the result )

            // Note : custom Data Annotation can be against the Database also not only with data from user (see "UniqueEmailValidation" )

            // Important Note : Custom Data Annotations works only Server side (when submitting the form) , can work client side but it's a work around way
            //                  that will not be discussed now .. (it's same as summary !! )

        }
    }
}
