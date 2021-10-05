using BusLay.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var produc = new Product
            {
                Name = product.Name,
                ImagePath = product.ImagePath,
                Description = product.Description,
                UnitPrice = product.UnitPrice
            };
            foreach (var item in product.Categories)
            {
                var category = context.Categories
                    .Where(w => w.Id == item.Id).FirstOrDefault();
                produc.Categories.Add(category);
            }
            context.Products.Add(produc);
           
               var usad= context.SaveChanges();


            return new Product {
                Id = produc.Id,
                Name = produc.Name,
                Description = produc.Description,
                UnitPrice = produc.UnitPrice,
                Categories = produc.Categories
            };
        }
        //private IQueryable<object> GetNewProduct(Product product)
        //{
        //    var product = context.Products.Where()
        //}
        public void DeleteProduct(int? id)
        {
            try
            {
                var product = FindProduct(id);
                product.IsDisable = true;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            } 
        }
        public IQueryable<object> GetAllProducts() 
        {
            var products = context.Products.Where(prod=>prod.IsDisable==false)
                     .Select(product =>
                     new
                     {
                         Id = product.Id,
                         Name = product.Name,
                         Categories = product.Categories.Select(category => new 
                         {
                             id=category.Id,
                             categoryName=category.CategoryName,
                             description=category.Description
                         })
                     });
            return products;
        }
    //    var result = dbContext.Teams
    //.Where(team => ...
    //.select(team => new
    //{   // select only the properties you will be using:
    //    Name = team.Name,
    //    ...
    //    // Select only the Players of this team you want:
    //    OlderPlayers = team.Players
    //        .Where(player => player.Age > 20)
    //        .Select(player => new
    //        {   // select only the player properties you plan to use:
    //            Name = player.Name,
    //            Position = player.Position,
    //            ...
    //         }),
    //});




        public Product EditProduct(Product product)
        {
            var produc = FindProduct(product.Id);
            produc.Name = product.Name;
            produc.ImagePath = product.ImagePath;
            produc.Description = product.Description;
            produc.UnitPrice = product.UnitPrice;
            foreach (var item in product.Id.ToString())
            {
                var categories = context.Categories.Where(w => w.Id == item).FirstOrDefault();
                produc.Categories.Add(categories);
            }

            context.SaveChanges();
            return product;
        }

        public Product FindProduct(int? productId)
        {
            var product = context.Products.Where(p => p.Id == productId).FirstOrDefault();
            return product;
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
