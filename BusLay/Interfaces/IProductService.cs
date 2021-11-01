using BusLay.DTOs;
using DAL.Entities;
using DAL.Filter;
using DAL.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface IProductService
    {
        public Product CreateProduct(Product dTO);
        public Task<Product> EditProduct(Product product);
        public Task<object> FindProduct(int? productId);
        public void DeleteProduct(int id);
        public List<Product> GetProduct(string productName,double? maxprice);
        public Task<List<ProductDTO>> ListProducts(PaginationFilter filter);
        public int ProductsCount();
        //public List<Product> ProductsByCategory(int categoryID);

    }
}