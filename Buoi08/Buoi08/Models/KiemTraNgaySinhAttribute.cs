using System;
using System.ComponentModel.DataAnnotations;

namespace Buoi08.Models
{
    internal class KiemTraNgaySinhAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime ngaysinh = (DateTime) value;
            if(ngaysinh > DateTime.Today)
            {
                return new ValidationResult("Ngày sinh trong tương lai");
            }

            return ValidationResult.Success;
        }
    }
}