using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyeStoreProject.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required]
        public string Password { get; set; }
    }
}
