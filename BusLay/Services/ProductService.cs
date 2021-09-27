using BusLay.Context;
using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Services
{
    public class ProductService:IProductService
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
                Description=dTO.Description,
                Name=dTO.ProductName,
                UnitPrice=dTO.UnitPrice,
                CategoryId=dTO.CategoryID,

            };
            repos.CreateProduct(product);
            return product;
        }
        public List<Product> ProductsByCategory(int categoryID) 
        {
            var products = repos.ProductsByCategory(categoryID);
            return products;
        }

        public string DeleteProduct(int id)
        {
           var product=  repos.DeleteProduct(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            return product;
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

        public List<Product>GetProduct(string productName,double? max)
        {
            var products = repos.ProductByName(productName,max);
            return products;
        }


    }
}
