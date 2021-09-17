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
        private readonly DataContext context;
        public ProductService(IProductRepository product, DataContext context)
        {
            repos = product;
            this.context = context;
        }

        public Product CreateProduct(ProductDTO dTO)
        {
            var product = new Product
            {
                Description=dTO.Description,
                Name=dTO.ProductName,
                UnitPrice=dTO.UnitPrice
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

        public Product GetProduct(string productName)
        {
            var product = repos.ProductByName(productName);
            return product;
        }
    }
}
