using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi02.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult DemoHinhHoc()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LayMot()
        {
            //đọc csdl/file
            var hh = new HangHoa
            {
                MaHangHoa = 1, 
                TenHangHoa = "TOSHIBA",
                DonGia = 179000
            };

            //đổ sang View hiển thị
            return View(hh);
        }

        public IActionResult DanhSach()
        {
            List<HangHoa> danhsach = new List<HangHoa>();
            HangHoa tmp;

            var rd = new Random();
            //sinh số phần tử ngẫu nhiên từ 3 -> 10
            var soPhanTu = rd.Next(3, 11);

            for(int i = 0; i < soPhanTu; i++)
            {
                tmp = new HangHoa
                {
                    MaHangHoa = i + 100,
                    TenHangHoa = $"Samsung {rd.Next()}",
                    DonGia = rd.NextDouble() * 10000000,
                    GiamGia = rd.NextDouble()
                };
                danhsach.Add(tmp);//Thêm vào mảng
            }

            return View(danhsach);
        }
    }
}