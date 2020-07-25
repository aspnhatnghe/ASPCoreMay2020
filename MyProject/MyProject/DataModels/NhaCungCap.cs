using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.DataModels
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        public int MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string DienThoai { get; set; }
        public string Logo { get; set; }
        public ICollection<HangHoa> HangHoas { get; set; }
        public NhaCungCap()
        {
            HangHoas = new HashSet<HangHoa>();
        }
    }
}
