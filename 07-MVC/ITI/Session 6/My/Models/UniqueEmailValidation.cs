using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace My.Models
{
    public class UniqueEmailValidation : ValidationAttribute
    {
        public UniqueEmailValidation()
        {
            
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)      // value => user input "Email"
        {
            if (value == null)
            {
                return new ValidationResult("Must enter an Email !! ");
            }
            if(value is string)
            {
                string email = (string)value;
                StdDbContext context = new();
                if(context.Students.Any(x=>x.Email == email))
                {
                    return new ValidationResult("Email Must be UNIQUE !! This email is taken ");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
                return new ValidationResult("Email Must be String");

            // What is the ValidationContext validationContext ? we didn't use it here !!! 
            // it's the full object returned from the form , as we may need other property from it , in our case it's a student object
            // ex: we can make validation for email , to be unique PER DEPARTMENT , so here we need the department data that is found in validationContext
            //
            // ex: if(context.Students.Any(x => x.Email == email) && ((Student)(validationContext.ObjectInstance)).DeptID == .....) 
        }
    }
}
