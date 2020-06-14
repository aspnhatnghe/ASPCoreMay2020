using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Buoi10_Layout.Models;
using Buoi10_Layout.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_Layout.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public ProductController(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public IActionResult Demo1()
        {
            var sp = new ProductModel
            {
                ProductId = 1, ProductName = "Beer",
                Price = 15900, Quantity = 1
            };

            var spMap = _mapper.Map<Product>(sp);

            return View(spMap);
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