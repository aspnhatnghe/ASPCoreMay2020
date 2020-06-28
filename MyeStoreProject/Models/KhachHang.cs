using System;
using System.Collections.Generic;

namespace MyeStoreProject.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            BanBe = new HashSet<BanBe>();
            HoaDon = new HashSet<HoaDon>();
            YeuThich = new HashSet<YeuThich>();
        }

        public string MaKh { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string Hinh { get; set; }
        public bool HieuLuc { get; set; }
        public int VaiTro { get; set; }

        public virtual ICollection<BanBe> BanBe { get; set; }
        public virtual ICollection<HoaDon> HoaDon { get; set; }
        public virtual ICollection<YeuThich> YeuThich { get; set; }
    }
}
