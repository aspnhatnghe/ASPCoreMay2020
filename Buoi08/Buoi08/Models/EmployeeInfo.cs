using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi08.Models
{
    public class EmployeeInfo
    {
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage ="*")]
        public string FullName { get; set; }

        [Display(Name = "Tuổi")]
        [Required(ErrorMessage = "*")]
        public int Age { get; set; }

        [Display(Name ="Mô tả")]
        [MaxLength(255, ErrorMessage = "Tối đa 255 kí tự")]
        [DataType(DataType.MultilineText)]
        public string Detail { get; set; }
    }
}
