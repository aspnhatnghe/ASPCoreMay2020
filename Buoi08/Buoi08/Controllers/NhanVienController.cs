using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi08.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi08.Controllers
{
    public class NhanVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemNhanVien(NhanVien nv)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Server chưa hợp lệ");
            }
            return View();
        }
    }
}