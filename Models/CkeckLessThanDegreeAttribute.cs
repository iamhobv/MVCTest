using System.ComponentModel.DataAnnotations;

namespace lab2.Models
{
    public class CkeckLessThanDegreeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int minDeg = int.Parse(value.ToString());
            CourseWithDeptInsVM crsFromValidation = (CourseWithDeptInsVM)validationContext.ObjectInstance;
            int crsDegree = crsFromValidation.Degree;
            if (crsDegree > minDeg)
            {
                return ValidationResult.Success;
            }



            return new ValidationResult("Min Degree must be less than the couruse degree");

        }
    }
}
