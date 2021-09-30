using BusLay.Context;
using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
                Name = dTO.Name,
                UnitPrice = dTO.UnitPrice,
                Categories = dTO.Categories
            };

            var pro= repos.CreateProduct(product);
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

        public Product EditProduct(Product product)
        {
            var newproduct = repos.EditProduct(product);
            return newproduct;
        }

        public Product FindProduct(int productId)
        {
            var product = repos.FindProduct(productId);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = repos.GetAllProducts();
            return products;
        }

        public List<Product> GetProduct(string productName, double? max)
        {
            var products = repos.ProductByName(productName, max);
            return products;
        }


    }
}
