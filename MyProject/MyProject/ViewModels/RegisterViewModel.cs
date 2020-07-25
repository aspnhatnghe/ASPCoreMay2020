
using System.ComponentModel.DataAnnotations;

namespace MyProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string Password { get; set; }
    }
}
