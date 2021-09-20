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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        public CategoryService(ICategoryRepository repository)
        {
            this.repository = repository;
        }
        public Category AddCategory(Category category)
        {
            repository.AddCategory(category);
            return category;
        }

        public string DeleteCategory(int id)
        {
            var deletedCategory = repository.DeleteCategory(id);
            return deletedCategory;
        }

        public Category GetCategory(int categoryId)
        {
            var category = repository.GetCategory(categoryId);
            return category;
        }
    }
}
