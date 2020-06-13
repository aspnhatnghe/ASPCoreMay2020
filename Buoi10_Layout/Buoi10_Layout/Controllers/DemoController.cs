using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi10_Layout.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_Layout.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LayDanhMuc()
        {
            var danhMuc = new DanhMuc
            {
                TenDanhMuc = "Điện thoại",
                SanPham = new string[] { "LG", "SONY", "Samsung", "Vin" }
            };

            return PartialView("_DanhMuc", danhMuc);
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}