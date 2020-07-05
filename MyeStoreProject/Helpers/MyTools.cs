using Microsoft.Extensions.Primitives;
using MyeStoreProject.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace MyeStoreProject.Helpers
{
    public class MyTools
    {
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
    }
}