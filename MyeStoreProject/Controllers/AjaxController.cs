using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
            return View();
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

    }
}