using MyProject.ViewModels;
using System;

namespace MyProject.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public string TenHH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }
}
