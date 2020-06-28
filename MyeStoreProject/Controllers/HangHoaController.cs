using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyeStoreProject.Helpers;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;

namespace MyeStoreProject.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly eStore20Context _context;
        public HangHoaController(eStore20Context ctx)
        {
            _context = ctx;
        }

        public IActionResult Index(int? PageCount, string SapXep, int Page = 1)
        {
            var pageCount = PageCount.HasValue ? PageCount.Value : 20;
            if(!string.IsNullOrEmpty(SapXep))
            {
                SapXep = "TenHh";
            }

            ViewBag.Pager = new SelectList(MyTools.Pages, "Value", "Text", pageCount);

            var result = _context.HangHoa.Select(p => new HangHoaViewModel
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia.Value,
                Hinh = MyTools.CheckImageExist(p.Hinh, "HangHoa"),
                GiamGia = p.GiamGia,
                NgaySX = p.NgaySx
            });
            switch(SapXep.ToLower())
            {
                case "tenhh": result = result.OrderBy(p => p.TenHh); break;
                case "dongia": result = result.OrderBy(p => p.DonGia).ThenBy(p => p.TenHh); break;
            }

            var danhsach = result.Skip((Page - 1) * pageCount)
                .Take(pageCount).ToList();

            return View(danhsach);
        }

        [HttpGet]
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimKiem(string Keyword, int? GiaTu, int? GiaDen)
        {
            var dsHangHoa = _context.HangHoa.Where(hh => hh.TenHh.Contains(Keyword));

            if (GiaTu.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia >= GiaTu);
            }
            if (GiaDen.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia <= GiaDen);
            }

            var result = dsHangHoa.Select(p => new HangHoaViewModel
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia.Value,
                Hinh = MyTools.CheckImageExist(p.Hinh, "HangHoa"),
                GiamGia = p.GiamGia,
                NgaySX = p.NgaySx
            }).ToList();

            return View(result);
        }
    }
}