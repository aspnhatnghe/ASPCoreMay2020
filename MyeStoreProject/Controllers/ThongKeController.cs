using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;

namespace MyeStoreProject.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly eStore20Context _context;
        public ThongKeController(eStore20Context ctx)
        {
            _context = ctx;
        }

        #region [Raw SQL demo]
        public IActionResult RawQuery()
        {
            var param = "an";
            var data = _context.HangHoa
                .FromSqlRaw($"SELECT * FROM HangHoa WHERE TenHH LIKE '%{param}%'")
                .ToList();

            return Json(data);
        }

        public IActionResult RawQuery2()
        {
            var param = "an";
            var data = _context.HangHoa
                .FromSqlRaw($"SELECT * FROM HangHoa WHERE TenHH LIKE '%{param}%'")
                .Select(p => new HangHoaViewModel { 
                    MaHh = p.MaHh,
                    TenHh = p.TenHh,
                    DonGia = p.DonGia.Value,
                    GiamGia = p.GiamGia
                })
                .ToList();

            return Json(data);
        }

        public IActionResult RawQuery3()
        {
            var mahd = 10248;
            var data = _context.ChiTietHoaDonViewModels
                .FromSqlRaw($"SELECT * FROM ChiTietHoaDonView WHERE MaHD = {mahd}");

            return Json(data);
        }
        #endregion

        #region [Thống kê]
        public IActionResult Loai()
        {
            var loais = _context.Loai.ToDictionary(lo => lo.MaLoai);

            var data = _context.ChiTietHd
                .GroupBy(cthd => cthd.MaHhNavigation.MaLoai)
                .Select(g => new ThongKeTheoLoai
                {
                    TenLoai = loais[g.Key].TenLoai,
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia)),
                    SoLuong = g.Sum(cthd => cthd.SoLuong),
                    GiaThapNhat = g.Min(cthd => cthd.DonGia)
                }).ToList();
            return View(data);
            //return Json(data);
        }

        public IActionResult KhachHang()
        {
            var dsKhachHang = _context.KhachHang.ToDictionary(kh => kh.MaKh);

            var data = _context.ChiTietHd
                .GroupBy(cthd => new
                {
                    cthd.MaHdNavigation.MaKh,
                    cthd.MaHhNavigation.MaLoai
                })
                .Select(g => new
                {
                    dsKhachHang[g.Key.MaKh].HoTen,
                    g.Key.MaLoai,
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia))
                });

            return Json(data);
        }

        public IActionResult NamThang()
        {
            var data = _context.ChiTietHd
                .GroupBy(cthd => new
                {
                    cthd.MaHhNavigation.MaLoai,
                    Nam = cthd.MaHdNavigation.NgayDat.Year,
                    Thang = cthd.MaHdNavigation.NgayDat.Month
                })
                .Select(g => new
                {
                    g.Key.MaLoai,
                    ThoiGian = $"{g.Key.Thang}/{g.Key.Nam}",
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia * (1 - cthd.GiamGia))
                });

            return Json(data);
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}