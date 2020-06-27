using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_EFCore.Models
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
        public string MoTa { get; set; }
        [MaxLength(50)]
        public string Hinh { get; set; }

        public ICollection<HangHoa> HangHoas { get; set; }
    }
}
