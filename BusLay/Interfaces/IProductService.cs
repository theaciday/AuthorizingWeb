using BusLay.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface IProductService
    {
        public Product CreateProduct(ProductDTO dTO);
        public Product EditProduct(Product product);
        public Product FindProduct(int productId);
        public string DeleteProduct(int id);
        public Product GetProduct(string productName);
        public List<Product> GetAllProducts();
        public List<Product> ProductsByCategory(int categoryID);

    }
}