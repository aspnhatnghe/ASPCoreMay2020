using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi10_Layout.Models;
using Buoi10_Layout.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_Layout.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index()
        {
            var dsHH = _productServices.GetAll();
            return View(dsHH);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product sp)
        {
            _productServices.AddProduct(sp);
            return RedirectToAction("Index");
        }
    }
}