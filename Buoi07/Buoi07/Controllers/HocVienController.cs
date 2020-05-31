using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi07.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Buoi07.Controllers
{
    public class HocVienController : Controller
    {
        public IActionResult DemoJson()
        {
            var hv = new HocVien
            {
                MaSo = 1, TenHocVien = "Hoa",
                GioiTinh = true, SoDienThoai = "0909899789", DiemTrungBinh = 8.12
            };

            var data = new
            {
                HocVien = hv,
                TrungTam = "Nhất Nghệ",
                NgayThanhLap = new DateTime(2003,3,10)
            };
            return Json(data);
        }

        public IActionResult ThongTin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThongTin(HocVien hv, string Ghi)
        {
            if(Ghi == "Ghi file Text")
            {
                StreamWriter sw = new StreamWriter("HocVien.txt");
                sw.WriteLine(hv.MaSo);
                sw.WriteLine(hv.TenHocVien);
                sw.WriteLine(hv.SoDienThoai);
                sw.WriteLine(hv.DiemTrungBinh);
                sw.WriteLine(hv.GioiTinh);
                sw.Close();
            }
            else if(Ghi == "Ghi file JSON")
            {
                string chuoiJson = JsonConvert.SerializeObject(hv);
                System.IO.File.WriteAllText("HocVien.json", chuoiJson);
            }
            return View();
        }

        public IActionResult DocFileJSON()
        {
            var content = System.IO.File.ReadAllText("HocVien.json");
            var hocvien = JsonConvert.DeserializeObject<HocVien>(content);
            return View("ThongTin", hocvien);
        }

        public IActionResult DocFileText()
        {
            var content = System.IO.File.ReadAllLines("HocVien.txt");
            var hocvien = new HocVien
            {
                MaSo = int.Parse(content[0]),
                TenHocVien = content[1],
                SoDienThoai = content[2],
                DiemTrungBinh = double.Parse(content[3]),
                GioiTinh = content[4] == "true" ? true : false
            };
            return View("ThongTin", hocvien);
        }
    }
}