using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.DataModels;
using MyProject.Helpers;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public CartController(MyDbContext ctx, IMapper mapper)
        {
            _context = ctx; _mapper = mapper;
        }

        public List<CartItem> CartItems
        {
            get
            {
                var myCart = HttpContext.Session.GetSession<List<CartItem>>("GioHang");
                if (myCart == null)
                {
                    myCart = new List<CartItem>();
                }
                return myCart;
            }
        }

        public IActionResult Index()
        {
            return View(CartItems);
        }

        public IActionResult AddToCart(Guid id, int soLuong = 1, bool isAjaxCall = false)
        {
            //lấy cart đang có
            var myCart = CartItems;

            //xử lý
            var cartItem = myCart.SingleOrDefault(p => p.Id == id);
            if (cartItem != null)
            {
                //update số lượng
                cartItem.SoLuong += soLuong;
            }
            else
            {
                var hangHoa = _context.HangHoas.SingleOrDefault(p => p.Id == id);
                cartItem = _mapper.Map<CartItem>(hangHoa);
                cartItem.SoLuong = soLuong;
                myCart.Add(cartItem);
            }

            //update cart
            HttpContext.Session.SetSession("GioHang", myCart);

            //chuyển hướng
            if (isAjaxCall)
            {
                return Json(CartInfo);
            }

            return RedirectToAction("Index");
        }

        public CartInfo CartInfo => new CartInfo
        {
            SoLuong = CartItems.Count,
            TongTien = CartItems.Sum(p => p.ThanhTien)
        };
    }
}