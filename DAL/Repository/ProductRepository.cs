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
            return product;
                
        }

        public string DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product EditProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product FindProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
