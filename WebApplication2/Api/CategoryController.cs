using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult AddCategory(CategoryDTO category)
        {
            if (category!=null)
            {
              service.AddCategory(category);
                return Created("category",category);
            }
            return NoContent();
        }
        
        [HttpGet]
        [Authorize(Role.Admin)]
        public IActionResult GetCategory(int categoryId)
        {
            var category = service.GetCategory(categoryId);
            return Ok(category);
        }
        
        [HttpGet("list")]
        public IActionResult ListCategories(PaginationFilter filter) 
        {
            var category = service.ListCategories(filter);
            return Ok(category);
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Role.Admin)]
        public IActionResult DeleteCategory(int id)
        {
             service.DeleteCategory(id);
            return Ok();
        }

    }
}
