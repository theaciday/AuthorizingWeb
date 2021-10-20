using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Helpers;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Wrappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;
        private readonly IUriService uriService;
        private readonly IImageService imageService;
        private readonly IWebHostEnvironment environment;
        public ProductController(IProductService service, IUriService uriService, IImageService imageService, IWebHostEnvironment environment)
        {
            this.service = service;
            this.uriService = uriService;
            this.imageService = imageService;
            this.environment = environment;
        }
        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult CreateProduct(Product product)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (currentUser.Role != Role.Admin)
                return StatusCode(403, new { message = "Forbidden" });
            Product newProduct = service.CreateProduct(product);
            return Created("createproduct", newProduct);
        }
        [HttpPost]
        [Route("{productId}/image")]
        [Authorize(Role.Admin)]
        public async Task<IActionResult> CreateImageUrl(int productId, [FromForm] Image images)
        {
            images.ImageName = await SaveImage(images.ImageFile);
            images.ImageSrc = String
               .Format("{0}://{1}{2}/wwwroot/{3}",
               Request.Scheme,
               Request.Host,
               Request.PathBase,
               images.ImageName);
            var newImage = imageService.CreateImage(images);
            var productImageId = imageService.CreateProductImage(productId, newImage.Id);
            return Created("create", new ProductImageDTO { ImageSrc = images.ImageSrc, Id = productImageId });
        }
        //record id on delete 
        [HttpDelete]
        [Route("image/{id}")]
        [Authorize(Role.Admin)]
        public IActionResult RemoveImage(int id)//<- record id in table image(imageId)/product(productId)
        {
            imageService.RemoveImage(id);
            return NoContent();
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmss") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(environment.ContentRootPath, "wwwroot", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        [HttpPut]
        [Authorize(Role.Admin)]
        public IActionResult EditProduct(Product dTO)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (currentUser.Role != Role.Admin)
                return StatusCode(403, new { message = "Forbidden" });
            var product = service.EditProduct(dTO);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> FindProduct(int id)
        {
            var product = await service.FindProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new Response<object>(product));
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult ProductByName(string name, double? max)
        {
            var product = service.GetProduct(name, max);
            return Ok(product);
        }
        [HttpGet]
        [Authorize(Role.Admin)]
        public async Task<IActionResult> AllProducts([FromQuery] PaginationFilter filter)

        {
            var currentUser = (User)HttpContext.Items["User"];
            if (currentUser.Role != Role.Admin)
                return StatusCode(403, new { message = "Forbidden" });
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await service.ListProducts(validFilter);
            var totalRecords = service.ProductsCount();
            var pagedResponse = PaginationHelper.CreatePagedResponse(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedResponse);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Role.Admin)]
        public IActionResult DeleteProduct(int id)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (currentUser.Role != Role.Admin)
                return StatusCode(403, new { message = "Forbidden" });
            service.DeleteProduct(id);
            return Ok();
        }
    }
}
