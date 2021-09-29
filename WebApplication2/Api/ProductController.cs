using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult CreateProduct(ProductDTO dTO)
        {
            var product = service.CreateProduct(dTO);
            return Created("createproduct",product);
        }
        [HttpPut]
        [Authorize(Role.Admin)]
        public IActionResult EditProduct(Product dTO)
        {
            var product = service.EditProduct(dTO);
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult FindProduct(int id)
        {
            var product = service.FindProduct(id);
            if (product==null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult AllProducts()
        {
            var products = service.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult ProductByName(string name,double? max)
        {
            var product = service.GetProduct(name,max);
            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Role.Admin)]
        public IActionResult DeleteProduct(int id) 
        {
             service.DeleteProduct(id);
            return Ok();
        }
    }
}
