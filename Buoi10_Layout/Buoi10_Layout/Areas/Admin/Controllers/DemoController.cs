using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_Layout.Areas.Admin.Controllers
{
    [Area("admin")]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}