using System.ComponentModel.DataAnnotations;

namespace API_Filter.ViewModel
{
    public class AddressValidationAttribute: ValidationAttribute
    {
        public int MinLength { get; set; }
        public int MaxLength { get; set; }

        public AddressValidationAttribute(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("Address cant be null.");
            }

            var stringValue = value as string; //convert object value to string
            if(stringValue == null)
            {
                return new ValidationResult("Input datatype is incorrect");
            }

            if(stringValue.Length < MinLength || stringValue.Length > MaxLength)
            {
                return new ValidationResult("The password length is incorrect, plz try again");
            }

            return ValidationResult.Success;                       
        }


    }
}
