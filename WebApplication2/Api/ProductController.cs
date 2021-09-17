using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("create")]
        [Authorize(Role.Admin)]
        public IActionResult CreateProduct(ProductDTO dTO)
        {
            var product = service.CreateProduct(dTO);
            return Created("createproduct",product);
        }
        [HttpPut("editproduct")]
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
        [HttpGet("product/{id:int}")]
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
        [HttpGet("allproducts")]
        [AllowAnonymous]
        public IActionResult AllProducts() 
        {
            var products = service.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("productbyname")]
        [AllowAnonymous]
        public IActionResult ProductByName(string productName)
        {
            var product = service.GetProduct(productName);
            return Ok(product);
        }

        [HttpDelete("deleteproduct{id:int}")]
        [Authorize(Role.Admin)]
        public IActionResult DeleteProduct(int id) 
        {
            var product= service.DeleteProduct(id);
            return Ok(product);
        }
    }
}
