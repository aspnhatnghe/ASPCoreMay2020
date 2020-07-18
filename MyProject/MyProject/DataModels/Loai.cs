using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.DataModels
{
    [Table("Loai")]
    public class Loai
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }

        public int? MaLoaiCha { get; set; }
        [ForeignKey("MaLoaiCha")]
        public Loai LoaiCha { get; set; }
    }
}
