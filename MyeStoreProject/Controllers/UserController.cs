using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyeStoreProject.Models;
using MyeStoreProject.ViewModels;

namespace MyeStoreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly eStore20Context _context;
        private readonly AppSettings _appSettings;
        public UserController(eStore20Context ctx, IOptions<AppSettings> optionSettings)
        {
            _context = ctx;
            _appSettings = optionSettings.Value;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginVM model)
        {
            var kh = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.UserName && p.MatKhau == model.Password);

            if (kh == null)
            {
                return Ok(new ApiResult
                {
                    Success = false,
                    Message = "Invalid username or password"
                });
            }

            #region [cấp token]
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);
            var tokenInfo = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, kh.HoTen),
                    new Claim(ClaimTypes.Email, kh.Email),
                    new Claim(ClaimTypes.Role, "NhanVien")
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenInfo);
            #endregion

            return Ok(new ApiResultData<string>
            {
                Success = true,
                Message = "Login successful",
                Data = tokenHandler.WriteToken(token)
            });
        }
    }
}