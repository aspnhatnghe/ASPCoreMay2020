using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.DataModels;
using OfficeOpenXml;

namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoaiController : Controller
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        #region [Import/Export Excel]
        public IActionResult ExportExcel()
        {
            var dataLoai = _context.Loais.ToList();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var sheet1 = package.Workbook.Worksheets.Add("Loai");
                var sheet2 = package.Workbook.Worksheets.Add("Demo");

                //đổ dữ liệu vào sheet
                sheet1.Cells.LoadFromCollection(dataLoai, true);

                Random rd = new Random();
                sheet2.Cells[1, 1].Value = "DANH SÁCH LOẠI";
                sheet2.Cells[1, 2].Value = rd.Next();//B1
                sheet2.Cells[1, 3].Value = rd.Next();//C1
                sheet2.Cells[1, 4].Formula = "=B1+C1";

                package.Save();
            }

            stream.Position = 0;

            var fileName = $"DSLoai_{DateTime.Now:ddMMyyyyHHmmss}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [HttpGet]
        public IActionResult ImportExcel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ImportExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return View();
            }

            var dsLoai = new List<Loai>();
            #region [Đọc file]
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                using (var excel = new ExcelPackage(memoryStream))
                {
                    var sheet1 = excel.Workbook.Worksheets["Loai"];
                    int rowCount = sheet1.Dimension.Rows;

                    for (int i = 2; i <= rowCount; i++)
                    {
                        var loaiTemp = new Loai
                        {
                            MaLoai = int.Parse(sheet1.Cells[i, 1].Value.ToString()),
                            TenLoai = sheet1.Cells[i, 2].Value.ToString()
                        };

                        if (int.TryParse(sheet1.Cells[i, 3].Value.ToString(), out int maLoaCha))
                        {
                            loaiTemp.MaLoaiCha = maLoaCha;
                        }

                        dsLoai.Add(loaiTemp);
                    }
                }
            }
            #endregion

            #region [Xử lý data]
            foreach (var loai in dsLoai)
            {
                //dựa vào tên tìm xem loại có chưa
                var loaiDb = _context.Loais.SingleOrDefault(p => p.TenLoai == loai.TenLoai);
                //nếu có, update
                if (loaiDb != null)
                {

                }
                //nếu chưa, tạo mới
                else
                {

                }

            }
            #endregion

            return RedirectToAction("Index");
        }
        #endregion

        // GET: Admin/Loai
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Loais.Include(l => l.LoaiCha);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Admin/Loai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .Include(l => l.LoaiCha)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // GET: Admin/Loai/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai");

            ViewBag.DataLoai = _context.Loais.ToList();
            return View();
        }

        // POST: Admin/Loai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,MaLoaiCha")] Loai loai)
        {
            try
            {
                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiCha);
                return View(loai);
            }
        }

        // GET: Admin/Loai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais.FindAsync(id);
            if (loai == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiCha);
            return View(loai);
        }

        // POST: Admin/Loai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,TenLoai,MaLoaiCha")] Loai loai)
        {
            if (id != loai.MaLoai)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiExists(loai.MaLoai))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["MaLoaiCha"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", loai.MaLoaiCha);
            //return View(loai);
        }

        // GET: Admin/Loai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loai = await _context.Loais
                .Include(l => l.LoaiCha)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }

            return View(loai);
        }

        // POST: Admin/Loai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loai = await _context.Loais.FindAsync(id);
            _context.Loais.Remove(loai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiExists(int id)
        {
            return _context.Loais.Any(e => e.MaLoai == id);
        }
    }
}
