using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buoi08.Models;

namespace Buoi08.Controllers
{
    public class HomeController : Controller
    {
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

        public string DemoSync()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Demo demo = new Demo();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            sw.Stop();

            return $"Chạy hết {sw.ElapsedMilliseconds} ms";
        }

        public async Task<IActionResult> ABCDEF()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Demo demo = new Demo();
            var a = demo.Test01Async();
            var b = demo.Test02Async();
            var c = demo.Test03Async();
            await a; await b; await c;
            sw.Stop();

            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public IActionResult DemoRazor()
        {
            return View();
        }
    }
}
