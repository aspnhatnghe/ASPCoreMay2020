using System;
using System.Collections.Generic;

namespace MyeStoreProject.Models
{
    public partial class ChuDe
    {
        public ChuDe()
        {
            GopY = new HashSet<GopY>();
        }

        public int MaCd { get; set; }
        public string TenCd { get; set; }
        public string MaNv { get; set; }

        public virtual NhanVien MaNvNavigation { get; set; }
        public virtual ICollection<GopY> GopY { get; set; }
    }
}
