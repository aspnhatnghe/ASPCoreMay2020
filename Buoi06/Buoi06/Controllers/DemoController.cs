using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult TruyenDuLieu1()
        {
            ViewBag.NgayThanhLap = new DateTime(2003, 3, 10);
            ViewBag.Ten = "Nhất Nghệ";
            ViewData["Tuoi"] = 17;
            ViewData["DienThoai"] = "02839292274";

            ViewBag.SanPham = new HangHoa
            {
                MaHH = 1, TenHH = "Bia Sài Gòn",
                DonGia = 18900, GiamGia = 3
            };

            return View();
        }

        //--> /dien-thoai/samsung-galaxy
        [Route("/dien-thoai/{tenDienThoai}")]
        public IActionResult ChiTiet(string tenDienThoai)
        {
            return Content(tenDienThoai);
        }

        [Route("/{loai}/{sanpham}")]
        public IActionResult ChiTiet(string loai, string sanpham)
        {
            return Content($"{loai} - {sanpham}");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}