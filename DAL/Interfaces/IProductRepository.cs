﻿using DAL.Entities;
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
        public Product EditProduct(Product product);
        public Product FindProduct(int productId);
        public string DeleteProduct(int id);
        public Product ProductByName(string productName);
        public List<Product> GetAllProducts();
        public List<Product> ProductsByCategory(int categoryID);


    }
}
