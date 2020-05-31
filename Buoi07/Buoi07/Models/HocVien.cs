using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07.Models
{
    public class HocVien
    {
        [DisplayName("Mã học viên")]
        public int MaSo { get; set; }
        [DisplayName("Tên học viên")]
        public string TenHocVien { get; set; }
        [DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }
        [DisplayName("Điểm trung bình")]
        public double DiemTrungBinh { get; set; }
        [DisplayName("Giới tính")]
        public bool GioiTinh { get; set; }
    }
}
