using Buoi10_Layout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi10_Layout.Services.Interfaces
{
    public interface IProductServices
    {
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product FindById(int productId);
        IEnumerable<Product> GetAll();
    }
}
