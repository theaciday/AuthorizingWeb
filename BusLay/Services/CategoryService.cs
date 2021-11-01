using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using System.Collections.Generic;
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
        public Category AddCategory(CategoryDTO DTO)
        {
            var cat = new Category() { CategoryName = DTO.CategoryName, Description = DTO.Description };
            var result = repository.AddCategory(cat);
            return result;
        }

        public void DeleteCategory(int id)
        {
            repository.DeleteCategory(id);

        }
        public int CategoriesCount()
        {
            return repository.CategoriesCount();
        }
        public Task<Category> GetCategory(int categoryId)
        {
            var category = repository.GetCategory(categoryId);
            return category;
        }

        public async Task<List<Category>> ListCategories(PaginationFilter filter)
        {
            var categories = await repository.ListCategories(filter);
            return categories;
        }
    }
}
