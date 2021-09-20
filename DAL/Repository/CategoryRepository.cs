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
            return category;
        }

        public string DeleteCategory(int id)
        {
            var category = GetCategory(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return "successeful deleted";
        }

        public Category GetCategory(int categoryId)
        {
            var category = context.Categories.Where(w => w.CategoryID == categoryId).FirstOrDefault();
            return category;
        }
    }
}
