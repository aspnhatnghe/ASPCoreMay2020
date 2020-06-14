using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi10_Layout.Models;
using Buoi10_Layout.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_Layout.Controllers
{
    public class DemoController : Controller
    {
        private ITransientService _service1;
        private ITransientService _service2;
        private IScopedService _service3;
        private IScopedService _service4;
        private ISingletonService _service5;

        public DemoController(ITransientService s1, ITransientService s2, IScopedService s3, IScopedService s4, ISingletonService s5)
        {
            _service5 = s5;
            _service1 = s1;
            _service2 = s2;
            _service3 = s3;
            _service4 = s4;
        }

        public IActionResult DemoTransient()
        {
            ViewBag.Service5 = _service5.GetID();
            ViewBag.Service1 = _service1.GetID();
            ViewBag.Service2 = _service2.GetID();
            ViewBag.Service3 = _service3.GetID();
            ViewBag.Service4 = _service4.GetID();

            return View();
        }

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