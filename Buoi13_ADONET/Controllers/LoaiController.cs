using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buoi13_ADONET.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi13_ADONET.Controllers
{
    public class LoaiController : Controller
    {
        LoaiDataAccessLayer loaiDAL;

        public LoaiController()
        {
            loaiDAL = new LoaiDataAccessLayer();
        }

        public IActionResult Index()
        {
            return View(loaiDAL.GetLoais());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            int maLoaiThem = loaiDAL.AddLoai(loai);
            //return Redirect($"/Loai/Edit/{maLoaiThem}");
            return RedirectToAction("Edit", "Loai", new { id = maLoaiThem});
        }

        public IActionResult Edit(int id)
        {
            var loai = loaiDAL.GetLoai(id);

            return View(loai);
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            loaiDAL.UpdateLoai(loai);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                loaiDAL.DeleteLoai(id);
                TempData["ThongBao"] = "Xóa thành công!";
            }
            catch(Exception ex)
            {
                TempData["ThongBao"] = "Xóa không thành công!";
            }

            return RedirectToAction("Index");
        }
    }
}