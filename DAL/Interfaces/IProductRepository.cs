using DAL.Entities;
using DAL.Filter;
using DAL.Models;
using DAL.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IProductRepository
    {
        public Product CreateProduct(Product product);
        public Task<Product> EditProduct(Product product);
        public Task<object> FindProduct(int? productId);
        public Product FindProduct(int productId);
        public void DeleteProduct(int? id);
        public List<Product>ProductByName(string productName,double? maxprice);
        public Task<List<Product>> GetAllProducts(PaginationFilter filter);
        public  int ProductsCount();
        //public List<Product> ProductsByCategory(int categoryID);


    }
}
