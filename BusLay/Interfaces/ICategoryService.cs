using BusLay.DTOs;
using DAL.Entities;
using DAL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface ICategoryService
    {
        public Category AddCategory(CategoryDTO category);
        public Task<object> GetCategory(int categoryId);
        public void DeleteCategory(int id);
        public Task<List<Category>> ListCategories(PaginationFilter filter);
    }
}
