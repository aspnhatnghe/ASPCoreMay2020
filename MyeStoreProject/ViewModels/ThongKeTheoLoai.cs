using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyeStoreProject.ViewModels
{
    public class ThongKeTheoLoai
    {
        [Display(Name ="Loại")]
        public string TenLoai { get; set; }
        [Display(Name ="Doanh thu")]
        public double DoanhThu { get; set; }
        [Display(Name = "Số lượng mặt hàng")]
        public int SoLuong { get; set; }
        [Display(Name = "Giá thấp nhất")]
        public double GiaThapNhat { get; set; }
        [Display(Name = "Giá trung bình")]
        public double GiaTrungBinh { get; set; }
    }
}
