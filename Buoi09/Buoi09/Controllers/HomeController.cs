using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buoi09.Models;
using Microsoft.AspNetCore.Http;

namespace Buoi09.Controllers
{
    public class HomeController : Controller
    {
        public string SinhMaBaoMat()
        {
            return PhatSinhMaBaoMat();
        }
        public string PhatSinhMaBaoMat()
        {
            //Sinh ra mã ngẫu nhiêu
            Random rd = new Random();
            var maNgauNhien = rd.Next(1000, 10000).ToString();
            //Lưu session mã ngẫu nhiên đó
            HttpContext.Session.SetString("MaBaoMat", maNgauNhien);
            return maNgauNhien;
        }
        public IActionResult Validate()
        {
            ViewBag.MaNgauNhien = PhatSinhMaBaoMat();

            return View();
        }

        public string KiemTraMaBaoMat(string MaBaoMat)
        {
            var mabaomatServer = HttpContext.Session.GetString("MaBaoMat");
            return mabaomatServer.Equals(MaBaoMat) ? "true" : "false";
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
