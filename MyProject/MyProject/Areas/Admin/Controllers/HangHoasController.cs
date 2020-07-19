using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProject.DataModels;
using MyProject.Helpers;
using MyProject.ViewModels;

namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoasController : Controller
    {
        private readonly MyDbContext _context;

        public HangHoasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Admin/HangHoas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.HangHoas.Include(h => h.Loai);
            return View(await myDbContext.ToListAsync());
        }

        // GET: Admin/HangHoas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.Loai)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Create
        public IActionResult Create()
        {
            ViewBag.DataLoai = new LoaiDropdownVM
            {
                Data = _context.Loais.ToList()
            };
            return View();
        }

        // POST: Admin/HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaHH,TenHH,SoLuong,DonGia,MoTa,ChiTiet,GiamGia,MaLoai")] HangHoa hangHoa, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                if (Hinh != null)
                {
                    hangHoa.Hinh = await MyTools.ProcessUploadHinh(Hinh, "HangHoa");
                }

                hangHoa.Id = Guid.NewGuid();
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DataLoai = new LoaiDropdownVM
            {
                Data = _context.Loais.ToList()
            };
            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // POST: Admin/HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MaHH,TenHH,SoLuong,DonGia,MoTa,Hinh,ChiTiet,GiamGia,MaLoai")] HangHoa hangHoa)
        {
            if (id != hangHoa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.Id))
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
            ViewData["MaLoai"] = new SelectList(_context.Loais, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }

        // GET: Admin/HangHoas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoas
                .Include(h => h.Loai)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: Admin/HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hangHoa = await _context.HangHoas.FindAsync(id);
            _context.HangHoas.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(Guid id)
        {
            return _context.HangHoas.Any(e => e.Id == id);
        }
    }
}
