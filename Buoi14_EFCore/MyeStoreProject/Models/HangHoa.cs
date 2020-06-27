using System;
using System.Collections.Generic;

namespace MyeStoreProject.Models
{
    public partial class HangHoa
    {
        public HangHoa()
        {
            BanBe = new HashSet<BanBe>();
            ChiTietHd = new HashSet<ChiTietHd>();
            YeuThich = new HashSet<YeuThich>();
        }

        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public int MaLoai { get; set; }
        public string MoTaDonVi { get; set; }
        public double? DonGia { get; set; }
        public string Hinh { get; set; }
        public DateTime NgaySx { get; set; }
        public double GiamGia { get; set; }
        public int SoLanXem { get; set; }
        public string MoTa { get; set; }
        public string MaNcc { get; set; }

        public virtual Loai MaLoaiNavigation { get; set; }
        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual ICollection<BanBe> BanBe { get; set; }
        public virtual ICollection<ChiTietHd> ChiTietHd { get; set; }
        public virtual ICollection<YeuThich> YeuThich { get; set; }
    }
}
