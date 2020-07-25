using Microsoft.AspNetCore.Http;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyProject.Helpers
{
    public class MyTools
    {
        public static async Task<string> ProcessUploadHinh(IFormFile hinh, string folder)
        {
            string fileName = string.Empty;

            var fName = Path.Combine(FullPathFolderImage, folder, hinh.FileName);
            using(var file = new FileStream(fName, FileMode.Create))
            {
                await hinh.CopyToAsync(file);
                fileName = hinh.FileName;
            }

            return fileName;
        }

        public static string ImageToBase64(string fileName, string folder)
        {
            var fullPath = Path.Combine(FullPathFolderImage, folder, fileName);
            if (File.Exists(fullPath))
            {
                byte[] data = File.ReadAllBytes(fullPath);
                return Convert.ToBase64String(data);
            }

            return null;
        }

        public static string FullPathFolderImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh");

        public static string NoImage = "no-image-available.png";
        public static string CheckImageExist(string fileName, string folder)
        {
            if (File.Exists(Path.Combine(FullPathFolderImage, folder, fileName)))
            {
                return $"{folder}/{fileName}";
            }
            return NoImage;
        }

        public static List<PagingModel> Pages
        {
            get
            {
                return new List<PagingModel>()
                {
                    new PagingModel{Value = 10, Text = "10"},
                    new PagingModel{Value = 20, Text = "20"},
                    new PagingModel{Value = 50, Text = "50"},
                    new PagingModel{Value = 100, Text = "100" }
                };
            }
        }        

        

        public static string GetRandom(int length = 5)
        {
            var pattern = @"1234567890qazwsxedcrfvtgbyhn@#$%";
            Random rd = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append(pattern[rd.Next(0, pattern.Length)]);

            return sb.ToString();
        }
    }
}
