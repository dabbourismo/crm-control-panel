using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.MVC.Validators
{
    public class MustBeGreaterThanAttribute : ValidationAttribute
    {
        private decimal _required;
        public MustBeGreaterThanAttribute(double required)
        {
            _required = Convert.ToDecimal(required);
            ErrorMessage = "{0} must be greater than {1}";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is decimal))
            {
                throw new ValidationException("This validator only used with decimal values");
            }
            if (_required >= ((decimal)value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName));
            }
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, _required);
        }
    }
}