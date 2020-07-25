using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.ViewModels
{
    public class HangHoaViewModel
    {
        public Guid Id { get; set; }
        public string MaHH { get; set; }
        public string TenHH { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public byte? GiamGia { get; set; }
    }
}
