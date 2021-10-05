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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext context;
        public CategoryRepository(DataContext context)
        {
            this.context = context;
        }
        public Category AddCategory(Category category)
        {

            context.Categories.Add(category);
            context.SaveChanges();
        
            return new Category() {Id=category.Id,CategoryName=category.CategoryName,Description=category.Description };
        }
        public void DeleteCategory(int id)
        {
            var category = GetCategory(id);
            category.IsDisable = true;
            context.SaveChanges();
            
        }
        public List<Category> ListCategories()
        {
            var categories = context.Categories.Where(w => (w.Id!=0)&&(w.IsDisable==false)).ToList();

            return categories;
        }
        public IQueryable<object> CategoryByProduct(int id)
        {
            var products = context.Products
                 .Where(c => c.Id == id)
                 .Select(product => new {
                     ProductName = product.Name,
                     ProductList =product.Categories
                 });
            return products;

        }
        public Category GetCategory(int categoryId)
        {
            var category = context.Categories.Where(w => w.Id == categoryId).FirstOrDefault();
           
            return category;
        }
    }
}
