using Buoi10_Layout.Models;
using Buoi10_Layout.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi10_Layout.Services.Implements
{
    public class BasicProductServices : IProductServices
    {
        public static List<Product> products = new List<Product>();
        public void AddProduct(Product sp)
        {
            products.Add(sp);
        }

        public void DeleteProduct(int masp)
        {
            //LINQ
            var sanpham = products.SingleOrDefault(p => p.ProductId == masp);
            if(sanpham != null)
            {
                products.Remove(sanpham);
            }
        }

        public Product FindById(int productId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
