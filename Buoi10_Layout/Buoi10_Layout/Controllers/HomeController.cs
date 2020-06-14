using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Buoi10_Layout.Models;
using Buoi10_Layout.Services.Interfaces;

namespace Buoi10_Layout.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISingletonService _service;

        public HomeController(ILogger<HomeController> logger, ISingletonService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            ViewBag.Service = _service.GetID();
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
