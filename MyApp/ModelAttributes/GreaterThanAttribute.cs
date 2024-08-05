using System.ComponentModel.DataAnnotations;

namespace MyApp
{
    public class GreaterThanAttribute : ValidationAttribute
    {
        private readonly int _minValue;

        public GreaterThanAttribute(int minValue)
        {
            _minValue = minValue;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateTimeValue)
            {
                if (dateTimeValue.AddYears(_minValue).Date > DateTime.Now.Date)
                {
                    return new ValidationResult($"The date must be greater than {_minValue}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
