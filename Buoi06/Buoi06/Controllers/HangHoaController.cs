using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi06.Controllers
{
    public class HangHoaController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();
        public HangHoaController()
        {
            //dsHangHoa.Add(new HangHoa { 
            //    MaHH = 1, TenHH = "Bánh mì",
            //    DonGia = 45900, GiamGia = 1
            //});
            //dsHangHoa.Add(new HangHoa { 
            //    MaHH = 2, TenHH = "Phở",
            //    DonGia = 55900, GiamGia = 4
            //});
        }

        public IActionResult Index()
        {
            return View(dsHangHoa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hangHoa)
        {
            dsHangHoa.Add(hangHoa);

            return View("Index", dsHangHoa);

            //return Redirect("/HangHoa");
            //return RedirectToAction("Index", "HangHoa");
        }
    }
}