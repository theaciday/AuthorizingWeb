using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
        public Product CreateProduct(Product dTO)
        {
            var pro = repos.CreateProduct(dTO);
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

        public async Task<List<ProductDTO>> ListProducts(PaginationFilter filter)
        {
            var product = await repos.GetAllProducts(filter);
            var dTO = product.Select(product => new ProductDTO
            {
                Id = product.Id,
                Name = product.ProductName,
                Description = product.Description,
                UnitPrice = (double)product.UnitPrice,
                Images=product.Images,
                Categories = product.Categories.Select(category => new CategoryDTO
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                }
                ).ToList()
            }).ToList();
            return dTO;
        }

        public int ProductsCount()
        {
            return repos.ProductsCount();
        }
    }
}
