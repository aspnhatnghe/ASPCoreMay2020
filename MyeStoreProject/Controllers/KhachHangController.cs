using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyeStoreProject.Constants;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyeStoreProject.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _context;

        public KhachHangController(eStore20Context db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous, HttpGet]
        public IActionResult Login(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var khachHang = _context.KhachHang.SingleOrDefault(kh => kh.MaKh == model.UserName && kh.MatKhau == model.Password);

                if (khachHang != null)
                {
                    //đăng nhập thành công

                    //khai báo các claim
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, khachHang.HoTen),
                        new Claim(ClaimTypes.Email, khachHang.Email),
                        new Claim(ClaimTypes.Role, "KhachHang"),
                        new Claim(MyClaimTypes.MaKhachHang, khachHang.MaKh)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Profile");
                };
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Demo()
        {
            var claims = this.User;
            var makh = claims.FindFirst(MyClaimTypes.MaKhachHang).Value;
            var role = claims.FindFirst(ClaimTypes.Role).Value;

            return Content(makh + " - " + role);
        }
    }
}