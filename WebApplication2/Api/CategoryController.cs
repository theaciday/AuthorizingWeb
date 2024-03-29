﻿using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Helpers;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService service;
        private readonly IUriService uriService;
        public CategoryController(ICategoryService service, IUriService uriService)
        {
            this.service = service;
            this.uriService = uriService;
        }
        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult AddCategory(CategoryDTO category)
        {
            if (category != null)
            {
               var result= service.AddCategory(category);
                return Created("category", result);
            }
            return BadRequest();
        }

        [HttpGet("{id:int}")]
        [Authorize(Role.Admin)]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (currentUser.Role != Role.Admin)
                return StatusCode(403, new { message = "Forbidden" });
            var category = await service.GetCategory(categoryId);
            return Ok(new Response<Category>(category));
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> ListCategories([FromQuery] PaginationFilter filter)
        {
            try
            {
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var pagedData = await service.ListCategories(filter);
                var totalRecords = service.CategoriesCount();
                var pagedResponse = PaginationHelper.CreatePagedResponse(pagedData, validFilter, totalRecords, uriService, route);
                return Ok(pagedResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete("{id:int}")]
        [Authorize(Role.Admin)]
        public IActionResult DeleteCategory(int id)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (currentUser.Role != Role.Admin)
                return StatusCode(403, new { message = "Forbidden" });
            service.DeleteCategory(id);
            return Ok();
        }

    }
}
