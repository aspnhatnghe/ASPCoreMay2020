using MyProject.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.ViewModels
{
    public class LoaiDropdownVM
    {
        public List<Loai> Data { get; set; }
        public int? Selected { get; set; }
        public string FileName { get; set; }
    }
}
