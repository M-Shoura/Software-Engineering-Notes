using System.ComponentModel.DataAnnotations;

namespace My.Models
{
    public class MinAgeValidation : ValidationAttribute
    {
        public int Age { get; }
        public MinAgeValidation(int age)             // in other cases we don't have to send parameters here (ex: Required)
        {
            Age = age;
        }
        public override bool IsValid(object? value)         // Value that the user entered in the form
        {
            if (value == null)
                return false;
            if (value is int)
            {
                int suppliedValue = (int)value;
                if (suppliedValue >= Age)
                {
                    return true;
                }
                else
                {
                    ErrorMessage = $"Age Value must be greater than or equal {Age}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
