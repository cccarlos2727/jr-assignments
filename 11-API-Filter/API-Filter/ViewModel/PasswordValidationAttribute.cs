using System.ComponentModel.DataAnnotations;

namespace API_Filter.ViewModel
{
    public class PasswordValidationAttribute: ValidationAttribute
    {       
        public int MaxLength { get; set; }

        public PasswordValidationAttribute(int maxLength)
        {            
            MaxLength = maxLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Password cant be null");
            }

            var stringValue = value as string;

            if(stringValue == null)
            {
                return new ValidationResult("Your input datatype is incorrect, plz try again.");
            }


            if(stringValue.Length > MaxLength)
            {
                return new ValidationResult("Your password exceed the max length, plz try again.");
            }

            return ValidationResult.Success;

            
        }
    }
}
