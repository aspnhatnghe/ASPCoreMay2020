using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.DataModels
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(10)]
        public string MaHH { get; set; }
        [MaxLength(100)]
        [Required]
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        [MaxLength(200)]
        public string MoTa { get; set; }
        public string ChiTiet { get; set; }
        [Range(0, 100)]
        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }
}
