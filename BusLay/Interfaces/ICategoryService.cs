using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface ICategoryService
    {
        public Category AddCategory(Category category);
        public Category GetCategory(int categoryId);
        public void DeleteCategory(int id);
        public List<Category> ListCategories();
    }
}
