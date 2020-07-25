using MyProject.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace MyProject.DataModels
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(10)]
        public string SKU { get; set; }
        [MaxLength(100)]
        [Required]
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        [MaxLength(200)]
        public string MoTa { get; set; }
        public string Hinh { get; set; }
        public string ChiTiet { get; set; }
        [Range(0, 100)]
        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
    }

    [Table("Hinh")]
    public class Hinh
    {
        [Key]
        public Guid Id { get; set; }
        public string Url { get; set; }
        public LoaiHinh LoaiHinh { get; set; }
        public Guid MaLoai { get; set; }
    }
}
