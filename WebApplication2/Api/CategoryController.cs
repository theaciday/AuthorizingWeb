using BusLay.Authorize;
using BusLay.Interfaces;
using DAL.Entities;
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
        public IActionResult AddCategory(Category category)
        {
            if (category!=null)
            {
              service.AddCategory(category);
                return Created("category",category);
            }
            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCategory(int categoryId)
        {
            var category = service.GetCategory(categoryId);
            return Ok(category);
        }
        
        [HttpDelete("{id:int}")]
        [Authorize(Role.Admin)]
        public IActionResult DeleteCategory(int id)
        {
            var deletedCategory = service.DeleteCategory(id);
            return Ok(deletedCategory);
        }

    }
}
