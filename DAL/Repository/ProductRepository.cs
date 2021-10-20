using BusLay.Context;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var produc = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                UnitPrice = product.UnitPrice,
            };
            foreach (var item in product.Categories)
            {
                var category = context.Categories
                    .Where(w => w.Id == item.Id).FirstOrDefault();
                produc.Categories.Add(category);
            }
            context.Products.Add(produc);
            context.SaveChanges();
            return new Product
            {
                Id = produc.Id,
                ProductName = produc.ProductName,
                Description = produc.Description,
                UnitPrice = produc.UnitPrice,
                Categories = produc.Categories,
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
                bool lal = true;
                var product = context.Products
                    .Where(prod => prod.Id == id)
                    .FirstOrDefault();
                product.IsDisable = lal;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> EditProduct(Product product)
        {
            var produc = await context.Products.Include(p => p.Id == product.Id).FirstOrDefaultAsync(prod => prod.Id == product.Id);
            produc.ProductName = product.ProductName;
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
        public async Task<List<Product>> GetAllProducts(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await context.Products
                .Where(prod => prod.IsDisable == false)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                     .Select(product =>
                     new Product
                     {
                         Id = product.Id,
                         ProductName = product.ProductName,
                         UnitPrice = product.UnitPrice,
                         Description = product.Description,
                         Categories = product.Categories.Select(category => new Category
                         {
                             Id = category.Id,
                             CategoryName = category.CategoryName,
                             Description = category.Description
                         }).ToList(),
                         Images = product.Images.Select(image => new ProductImage
                         {
                             Id = image.Id,
                             ProductImgEntity = image.ProductImgEntity
                         }).ToList(),
                     }).ToListAsync();

            return pagedData;
        }
        public int ProductsCount()
        {
            return context.Products.Where(w => w.IsDisable == false).Count();
        }

        public async Task<object> FindProduct(int? productId)
        {
            var product = await context.Products
                .Where(product => product.Id == productId)
                .Select(product => new
                {
                    Id = product.Id,
                    Name = product.ProductName,
                    Categories = product.Categories.Select(category => new
                    {
                        id = category.Id,
                        categoryName = category.CategoryName,
                        description = category.Description
                    })
                })
                .FirstOrDefaultAsync();

            return product;
        }
        public List<Product> ProductByName(string productName, double? maxprice)
        {
            return context.Products.Where(x =>
                (productName == null || x.ProductName.ToLower() == productName.ToLower()) &&
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
