﻿using BusLay.DTOs;
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
        public Category AddCategory(CategoryDTO DTO)
        {
            var cat = new Category() { CategoryName = DTO.CategoryName,Description=DTO.Description };
            repository.AddCategory(cat);
            return cat;
        }

        public void DeleteCategory(int id)
        {
         repository.DeleteCategory(id);
            
        }

        public Category GetCategory(int categoryId)
        {
            var category = repository.GetCategory(categoryId);
            return category;
        }

        public List<Category> ListCategories()
        {
            var categories = repository.ListCategories();
            return categories;
        }
    }
}
