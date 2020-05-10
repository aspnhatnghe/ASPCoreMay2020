using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Day01.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult TuDien()
        {
            return View();
        }

        //host:port/Demo/HinhChuNhat?dai=11&rong=9
        public IActionResult HinhChuNhat(double dai, double rong)
        {
            return View();
        }

        public IActionResult Demo()
        {
            return View();
        }

        // local:port/Demo/Chuoi
        public string Chuoi()
        {
            return "HEllo";
        }

        // local:port/Demo/So
        public int So()
        {
            return new Random().Next(1000, 10000);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}