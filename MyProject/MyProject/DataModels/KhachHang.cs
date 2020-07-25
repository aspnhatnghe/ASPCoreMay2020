using MyProject.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.DataModels
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string MatKhau { get; set; }
        public string RandomKey { get; set; }
        public bool TrangThai { get; set; } /*1: Active, 0: InActive*/
        public Role VaiTro { get; set; }

        public ICollection<DonHang> DonHangs { get; set; }
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }
    }
}
