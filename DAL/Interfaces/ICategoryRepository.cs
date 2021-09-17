using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface ICategoryRepository
    {
        public Category AddCategory(Category category);
        public Category GetCategory(int categoryId);
        public string DeleteCategory(int id);
    }
}
