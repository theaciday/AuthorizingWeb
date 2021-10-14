using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusLay.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repos;
        public ProductService(IProductRepository product)
        {
            repos = product;
        }
        public Product CreateProduct(ProductDTO dTO)
        {
            var product = new Product
            {
                Description = dTO.Description,
                ProductName = dTO.Name,
                UnitPrice = dTO.UnitPrice,
                Categories = dTO.Categories,
            };

            var pro = repos.CreateProduct(product);
            return pro;
        }
        //public List<Product> ProductsByCategory(int categoryID) 
        //{
        //    var products = repos.ProductsByCategory(categoryID);
        //    return products;
        //}
        public void DeleteProduct(int id)
        {
            repos.DeleteProduct(id);
        }

        public async Task<Product> EditProduct(Product product)
        {
            var newproduct = await repos.EditProduct(product);
            return newproduct;
        }

        public async Task<object> FindProduct(int productId)
        {
            var product = await repos.FindProduct(productId);
            return product;
        }


        public List<Product> GetProduct(string productName, double? max)
        {
            var products = repos.ProductByName(productName, max);
            return products;
        }

        public async Task<List<Product>> ListProducts(PaginationFilter filter)
        {
            return await repos.GetAllProducts(filter);
        }

        public int ProductsCount()
        {
            return repos.ProductsCount();
        }
    }
}
