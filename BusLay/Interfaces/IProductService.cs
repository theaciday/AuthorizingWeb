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
        public void DeleteProduct(int id);
        public List<Product> GetProduct(string productName,double? maxprice);
        public List<Product> GetAllProducts();
        //public List<Product> ProductsByCategory(int categoryID);

    }
}