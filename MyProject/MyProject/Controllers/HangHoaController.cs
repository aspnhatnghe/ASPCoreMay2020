using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.DataModels;
using MyProject.ViewModels;

namespace MyProject.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public HangHoaController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private List<int> DanhSachLoai(int maLoaiCha)
        {
            var result = new List<int>();
            var dsLoai = _context.Loais.Select(p => new { p.MaLoai, p.MaLoaiCha }).ToList();

            return result;
        }
        public IActionResult Index(int? MaLoai)
        {
            var dataHangHoa = _context.HangHoas.AsQueryable();
            if(MaLoai.HasValue)
            {
                dataHangHoa = dataHangHoa.Where(hh => hh.MaLoai == MaLoai.Value || hh.Loai.MaLoaiCha == MaLoai.Value).AsQueryable();

                //var dsLoai = DanhSachLoai(MaLoai.Value);
                //dataHangHoa = dataHangHoa.Where(hh => dsLoai.Contains(hh.MaLoai.Value)).AsQueryable();
            }
            var result = _mapper.Map<List<HangHoaViewModel>>(dataHangHoa.ToList());

            return View(result);
        }

        public IActionResult Detail(string id)
        {
            var hangHoaGuid = Guid.Parse(id);
            var hangHoa = _context.HangHoas
                .Include(prop => prop.Loai)
                .SingleOrDefault(hh => hh.Id == hangHoaGuid);

            return View(hangHoa);
        }
    }
}