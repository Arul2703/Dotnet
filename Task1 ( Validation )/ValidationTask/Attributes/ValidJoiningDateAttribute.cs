using System;
using System.ComponentModel.DataAnnotations;
using ValidationTask.Models;

namespace ValidationTask.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidJoiningDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime joiningDate)
            {
                var employee = validationContext.ObjectInstance as Employee;
                if (employee != null)
                {
                    var dateOfBirth = employee.DateOfBirth;
                    if (joiningDate.Date > dateOfBirth.Date)
                    {
                        return ValidationResult.Success;
                    }
                }
            }

            return new ValidationResult(ErrorMessage);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The {name} field must be a date later than the Date of Birth.";
        }
    }
}
