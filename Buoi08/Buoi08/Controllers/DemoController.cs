using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi08.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi08.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult ThemNhanVien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemNhanVien(EmployeeInfo employee)
        {
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}