using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ValidationTask.Attributes;

namespace ValidationTask.Models
{
    public class Employee
    {
        [StringLength(50)]
        [RegularExpression(@"^[A-Z][a-zA-Z]{2,}\s[A-Z][a-zA-Z\s]*$", ErrorMessage = "Invalid Name. Ex: Firstname Lastname")]
        [Required(ErrorMessage = "Full Name Required")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth Required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth{ get; set; }

        // Using Custom Validation Attribute
        [Required(ErrorMessage = "Date of Joining Required")]
        [Display(Name = "Date of Joining")]
        [DataType(DataType.Date)]
        [ValidJoiningDate(ErrorMessage = "Invalid date of joining. It should be after the date of birth.")]

        // [Required]
        // [Display(Name = "Date of Joining")]
        // [DataType(DataType.Date)]
        // [Remote("ValidateDateOfJoining", "Employee", AdditionalFields = "DateOfBirth", ErrorMessage = "Invalid date of joining. It should be after the date of birth.")]
        [Remote(action: "ValidateDateOfJoining", controller: "Employee", ErrorMessage = "Invalid date of joining. It should be after the date of birth.")]
        public DateTime DateOfJoining { get; set; }


        // public DateTime DateOfJoining { get; set; }
    }
}
