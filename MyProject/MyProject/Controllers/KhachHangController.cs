using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Common;
using MyProject.Constants;
using MyProject.DataModels;
using MyProject.Helpers;
using MyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly MyDbContext _context;

        public KhachHangController(MyDbContext context)
        {
            _context = context;
        }

        #region [Đăng ký]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(RegisterViewModel model)
        {
            var kh = new KhachHang
            {
                MaKhachHang = Guid.NewGuid().ToString(),
                TenKhachHang = model.CustomerName,
                DienThoai = model.Phone,
                Email = model.Email,
                TrangThai = false,
                RandomKey = MyTools.GetRandom(),
                VaiTro = Common.Role.Customer
            };
            kh.MatKhau = model.Password.ToSHA512Hash(kh.RandomKey);
            _context.Add(kh);
            _context.SaveChanges();

            try
            {
                var urlActive = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/KhachHang/ActiveAccount?id={kh.MaKhachHang}";
                var noidungMail = @$"<div>
            <i>Dear anh/chị <b>{kh.TenKhachHang}</i>
<div>Bạn đã đăng ký thành công tài khoản tại .... Vui lòng click vào <a href={urlActive}>đây</a> để kích hoạt.</div>
Trân trọng./.
</div>";
                GoogleMailer.Send(kh.Email, "Active tai khoan", noidungMail);
            }
            catch (Exception ex)
            {

            }
            return Redirect("/HangHoa");
        }
        #endregion


        #region [Đăng nhập]
        public IActionResult DangNhap(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginViewModel model, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var khachHang = _context.KhachHangs.SingleOrDefault(p => p.Email == model.Email);
                if (khachHang != null && khachHang.MatKhau == model.Password.ToSHA512Hash(khachHang.RandomKey))
                {
                    //khai báo các claim
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, khachHang.TenKhachHang),
                        new Claim(ClaimTypes.Email, khachHang.Email),
                        new Claim(ClaimTypes.Role, khachHang.VaiTro.ToString()),
                        new Claim(MyClaimTypes.MaKhachHang, khachHang.MaKhachHang)
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
        #endregion

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Accountant")]
        public IActionResult Profile()
        {
            //if (!User.IsInRole(Role.Accountant.ToString())){
            //    return Redirect("/Home/AccessDenied");
            //}
            return View();
        }
    }
}