using DAL.Entities;
using DAL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICategoryRepository
    {
        public Category AddCategory(Category category);
        Task<object> GetCategory(int categoryId);
        public void DeleteCategory(int id);
        public Task<List<Category>> ListCategories(PaginationFilter filter);
    }
}
