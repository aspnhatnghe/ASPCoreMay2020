using System;
using System.Collections.Generic;

namespace MyeStoreProject.Models
{
    public partial class BanBe
    {
        public int MaBb { get; set; }
        public string MaKh { get; set; }
        public int MaHh { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public DateTime NgayGui { get; set; }
        public string GhiChu { get; set; }

        public virtual HangHoa MaHhNavigation { get; set; }
        public virtual KhachHang MaKhNavigation { get; set; }
    }
}
