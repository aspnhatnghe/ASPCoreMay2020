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
        public IActionResult KiemTraMaNhanVien(int MaNhanVien)
        {
            //giả sử tập mã NV đang có (mai mốt lấy ở CSDL)
            int[] dsMa = new int[] { 777, 2222, 999, 123, 369, 1515 };

            if(dsMa.Contains(MaNhanVien))
            {
                return Json("Mã này đã có");
            }

            return Json(true);
        }

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
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Server chưa hợp lệ");
            }
            return View();
        }
    }
}