using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi07.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Upload()
        {
            return View();
        }

        public IActionResult UploadSingleFile(IFormFile myfile)
        {
            if(myfile != null)
            {
                var filename = Path.Combine(Directory.GetCurrentDirectory(), 
                    "wwwroot", "data", 
DateTime.Now.Ticks.ToString() + myfile.FileName);

                using(var filestream = new FileStream(filename, FileMode.Create))
                {
                    myfile.CopyTo(filestream);
                }
            }

            return RedirectToAction("Upload", "Demo");
        }

        public IActionResult UploadMultipleFile(List<IFormFile> myfile)
        {
            if (myfile != null)
            {
                foreach (var file in myfile)
                {
                    var filename = Path.Combine(Directory.GetCurrentDirectory(), "Documents",
    DateTime.Now.Ticks.ToString() + file.FileName);

                    using (var filestream = new FileStream(filename, FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                }
            }

            return RedirectToAction("Upload", "Demo");
        }
    }
}
