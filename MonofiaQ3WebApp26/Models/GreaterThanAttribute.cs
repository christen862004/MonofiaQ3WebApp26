using System.ComponentModel.DataAnnotations;

namespace MonofiaQ3WebApp26.Models
{
    public class GreaterThanAttribute:ValidationAttribute
    {
        public GreaterThanAttribute(int compareval)
        {
            CompareVal = compareval;
        }
        public int CompareVal { get; set; } = 0;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int val = int.Parse(value.ToString());
            if (val > CompareVal)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult($"Val {val} less than {CompareVal}");
        }
    }
}
