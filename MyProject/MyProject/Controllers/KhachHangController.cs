using Microsoft.AspNetCore.Mvc;
using MyProject.DataModels;
using MyProject.Helpers;
using MyProject.ViewModels;
using System;

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
            catch(Exception ex)
            {

            }
            return Redirect("/HangHoa");
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}