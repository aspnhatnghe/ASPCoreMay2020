using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyeStoreProject.ViewModels
{
    public class HangHoaViewModel
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }
        public double GiaBan => DonGia * (1 - GiamGia);
        public DateTime NgaySX { get; set; }
    }
}
