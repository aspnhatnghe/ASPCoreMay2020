using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyeStoreProject.Helpers;
using MyeStoreProject.Models;

namespace MyeStoreProject.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult WriteSession()
        {
            HttpContext.Session.SetInt32("NamThanhLap", 2003);
            HttpContext.Session.SetString("Ten", "Nhất Nghệ");

            var loai = new Loai
            {
                MaLoai = 1, TenLoai = "Bia"
            };
            HttpContext.Session.SetSession<Loai>("loai", loai);

            return Redirect("/Demo/Index");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}