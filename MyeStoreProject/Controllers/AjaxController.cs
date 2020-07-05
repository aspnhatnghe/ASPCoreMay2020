using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyeStoreProject.Helpers;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;

namespace MyeStoreProject.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;
        public AjaxController(eStore20Context ctx)
        {
            _context = ctx;
        }

        public IActionResult Index()
        {
            ViewBag.TongSoTrang = (int)Math.Ceiling(1.0 * _context.HangHoa.Count() / SO_SP_MOI_TRANG);
            return View();
        }

        const int SO_SP_MOI_TRANG = 9;

        public IActionResult LoadMore(int page = 1)
        {
            var result = _context.HangHoa
                .Skip((page - 1) * SO_SP_MOI_TRANG)
                .Take(SO_SP_MOI_TRANG)
                .Select(p => new HangHoaViewModel
            {
                MaHh = p.MaHh,
                TenHh = p.TenHh,
                DonGia = p.DonGia.Value,
                Hinh = MyTools.CheckImageExist(p.Hinh, "HangHoa"),
                GiamGia = p.GiamGia,
                NgaySX = p.NgaySx
            });

            return PartialView(result);
        }

        public IActionResult ServerTime()
        {
            return Content(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt"));
        }

        #region [Tìm kiếm Hàng hóa theo tên]
        //request:  /Ajax/HangHoa
        public IActionResult HangHoa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string Keyword)
        {
            var data = _context.HangHoa
                .Where(hh => hh.TenHh.ToLower().Contains(Keyword))
                .Select(hh => new HangHoaViewModel { 
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia.Value,
                    GiamGia = hh.GiamGia,
                    Hinh = hh.Hinh,
                    NgaySX = hh.NgaySx
                });

            return PartialView(data);
        }
        #endregion

        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JsonSearch(JsonSearchModel model)
        {
            var data = _context.HangHoa.AsQueryable();

            if(!string.IsNullOrEmpty(model.TenHh))
            {
                data = data.Where(hh => hh.TenHh.Contains(model.TenHh));
            }
            if(model.GiaTu > 0)
            {
                data = data.Where(hh => hh.DonGia >= model.GiaTu);
            }
            if (model.GiaDen > 0)
            {
                data = data.Where(hh => hh.DonGia <= model.GiaDen);
            }

            var result = data.Select(hh => new { 
                hh.TenHh, hh.DonGia,
                hh.MaLoaiNavigation.TenLoai,
                //hh.Hinh
                Hinh = MyTools.ImageToBase64(hh.Hinh, "HangHoa")
            }).ToList();

            return Json(result);
        }
    }
}