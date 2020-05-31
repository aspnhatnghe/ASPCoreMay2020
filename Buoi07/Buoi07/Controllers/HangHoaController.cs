using Buoi07.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07.Controllers
{
    public class HangHoaController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();

        public IActionResult Index()
        {
            return View(dsHangHoa);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hh, IFormFile Hinh)
        {
            if(Hinh != null)
            {
                var fileName = $"{DateTime.Now.Ticks}_{Hinh.FileName}";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "hanghoa", fileName);
                hh.Hinh = fileName;
                using(var file = new FileStream(fullPath, FileMode.Create))
                {
                    Hinh.CopyTo(file);
                    dsHangHoa.Add(hh);
                    return Redirect("/HangHoa");
                }
            }

            return View();
        }
    }
}
