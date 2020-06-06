using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi08.Models
{
    public class NhanVien
    {
        public int ID { get; set; }

        [Display(Name ="Mã nhân viên")]
        [Required(ErrorMessage ="*")]
        [Remote(action:"KiemTraMaNhanVien", controller:"NhanVien")]
        public int MaNhanVien { get; set; }

        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "*")]
        public string TenNhanVien { get; set; }

        [EmailAddress(ErrorMessage ="Không đúng định dạng email")]
        public string Email { get; set; }

        [Url]
        public string Website { get; set; }

        [Display(Name ="Ngày sinh")]
        [DataType(DataType.Date)]
        [KiemTraNgaySinh]
        public DateTime NgaySinh { get; set; }

        [Display(Name ="Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name ="Lương")]
        [Range(0, double.MaxValue)]
        public double Luong { get; set; }

        public string DiaChi { get; set; }
        public string DienThoai { get; set; }

        [CreditCard]
        public string SoTaiKhoan { get; set; }
        
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string ThongTinThem { get; set; }
        
        //[DataType(DataType.Password)]
        [Required(ErrorMessage ="*")]
        [MinLength(4, ErrorMessage ="Tối thiểu 4 kí tự")]
        [RegularExpression("[0-9]+[A-Z]+[a-z]+[@#$%^&*~]+", ErrorMessage ="Mật khẩu phải chứa ít nhất 1 chữ số, 1 chữ hoa, 1 chữ thường, 1 ký tự đặc biệt")]
        public string MatKhau { get; set; }

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "*")]
        [Compare("MatKhau", ErrorMessage ="Mật khẩu không khớp")]
        public string NhapLaiMatKhau { get; set; }
    }
}
