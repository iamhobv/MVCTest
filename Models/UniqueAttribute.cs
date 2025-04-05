using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace lab2.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        databaseContext context = new databaseContext();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string crsName = value.ToString();

            Course crsFromDb = context.Courses.FirstOrDefault(c => c.Name == crsName);

            if (crsFromDb == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Course already exists");
        }
    }
}
