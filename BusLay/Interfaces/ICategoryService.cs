using BusLay.DTOs;
using DAL.Entities;
using DAL.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface ICategoryService
    {
        public Category AddCategory(CategoryDTO category);
        public Task<Category> GetCategory(int categoryId);
        public void DeleteCategory(int id);
        public Task<List<Category>> ListCategories(PaginationFilter filter);
        public int CategoriesCount();
    }
}
