using Buoi10_Layout.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi10_Layout.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IProductServices _services;
        public CategoryMenu(IProductServices services)
        {
            _services = services;
        }

        public IViewComponentResult Invoke()
        {
            return View("Default", _services.GetAll());
        }
    }
}
