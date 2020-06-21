using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi13_ADONET.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Buoi13_ADONET.Controllers
{
    public class DemoController : Controller
    {
        private readonly SQLConfig _sqlConfig;
        public DemoController(IOptions<SQLConfig> sqlConfig)
        {
            _sqlConfig = sqlConfig.Value;
        }

        public IActionResult DemoInsert()
        {
            SqlConnection connection = new SqlConnection(_sqlConfig.ConnectionString);
            
            string sqlInsert = "INSERT INTO Loai(TenLoai) VALUES(N'Bia - Nước ngọt')";
            SqlCommand command = new SqlCommand(sqlInsert, connection);
            command.Connection.Open();
            int result = command.ExecuteNonQuery();
            command.Connection.Close();

            return Content($"{result} effected row(s).");
        }

        public IActionResult Demo()
        {
            SqlConnection connection = new SqlConnection(_sqlConfig.ConnectionString);

            string sql = "SELECT TOP 100 MaHH, TenHH, DonGia, Hinh FROM HangHoa";

            SqlDataAdapter da = new SqlDataAdapter(sql, connection);
            DataTable dtHangHoa = new DataTable();
            da.Fill(dtHangHoa);


            return View(dtHangHoa);
        }

        public IActionResult Index()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("myappsettings.json");
            var config = builder.Build();
            var ngaykg = config["NgayKhaiGiang"];
            var tentt = config["TrungTam:Ten"];
            var conhd = config["TrungTam:ConHoatDong"];
            var myDbCon = config.GetConnectionString("MyDB");
            var trungtam = config.GetSection("TrungTam");
            var dienthoai = trungtam["DienThoai"];

            var ketqua = $"{tentt}, đang hoạt động: {conhd}, {dienthoai}. Chuỗi kết nối: {myDbCon}";

            return Content(ketqua);
        }
    }
}