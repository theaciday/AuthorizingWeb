using BusLay.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext context;
        public ProductRepository(DataContext _context)
        {
            context = _context;
        }

        public Product CreateProduct(Product product)
        {
            context.Products.Add(product);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            context.SaveChanges();
            return product;

        }

        public void DeleteProduct(int? id)
        {
            FindProduct(id); 
        }

        public Product EditProduct(Product product)
        {
            var produc = FindProduct(product.Id);
            produc.Name = product.Name;
            produc.ImagePath = product.ImagePath;
            produc.Description = product.Description;
            produc.UnitPrice = product.UnitPrice;
            produc.Categories = product.Categories;
            context.SaveChanges();
            return product;
        }

        public Product FindProduct(int? productId)
        {
            var product = context.Products.Where(p => p.Id == productId).FirstOrDefault();
            return product;
        }
        //public List<Product> ProductsByCategory(int categoryID)
        //{
        //    var products = context.Products.Where(p => p.Categories == categoryID).ToList();
        //    return products;
        //}

        public List<Product> GetAllProducts()
        {
            using var con = context;
            var products = con.Products.ToList();
            return products;
        }

        public List<Product> ProductByName(string productName, double? maxprice)
        {
            return context.Products.Where(x => 
                (productName == null || x.Name.ToLower() == productName.ToLower()) && 
                (maxprice == null || x.UnitPrice <= maxprice)
            ).ToList();
        }

        //public List<Product> ProductByName(string productName, double maxprice)
        //{CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS CONTAINS 
        //    var users = context.Products.Where(x => x.Name.ToLower() == productName.ToLower() && x.UnitPrice <= maxprice).ToList();
        //    return users;
        //}
    }
}
