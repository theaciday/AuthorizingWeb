using BusLay.Context;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            using (DataContext pop = context)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return new Category()
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
            }
        }
        public void DeleteCategory(int id)
        {
            using (DataContext pop = context)
            {
                var category = context.Categories
              .Where(category => category.Id == id)
              .FirstOrDefault();
                category.IsDisable = true;
                context.SaveChanges();
            }
        }
        public async Task<List<Category>> ListCategories(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            using (DataContext pop = context)
            {
                var pagedData = await context.Categories
                    .Skip((validFilter.PageNumber -1)*validFilter.PageSize)
                    .Take(validFilter.PageSize)
                    .Where(w => (w.Id != 0) && (w.IsDisable == false))
                    .Select(category=>new Category
                    {
                        Id=category.Id,
                        CategoryName=category.CategoryName,
                        Description=category.Description
                    }).ToListAsync();

                return pagedData;
            }
        }
        //public iqueryable<object> categorybyproduct(int id)
        //{
        //    var products = context.products
        //         .where(c => c.id == id)
        //         .select(product => new {
        //             productname = product.name,
        //             productlist =product.categories
        //         });
        //    return products;

        //}
        public async Task<object> GetCategory(int categoryId)
        {
            using (DataContext pop = context)
            {
                var category = await context.Categories
                .Where(category => category.Id == categoryId)
                .Select(category => new
                {
                    Id = category.Id,
                    Name = category.CategoryName,
                    Description = category.Description,
                    //category.Products?
                }).FirstOrDefaultAsync();

                return category;
            }
        }
    }
}
