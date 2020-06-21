using System.ComponentModel.DataAnnotations;

namespace Buoi13_ADONET.Models
{
    public class Loai
    {
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
        [MaxLength(50)]
        public string Hinh { get; set; }
        public string MoTa { get; set; }
    }
}
