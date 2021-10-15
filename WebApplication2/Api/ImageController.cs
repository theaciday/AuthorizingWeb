using BusLay.Authorize;
using BusLay.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly IImageService service;

        public ImageController(IWebHostEnvironment environment, IImageService service)
        {
            this.environment = environment;
            this.service = service;
        }
        [HttpPost("{productId}")]
        [Authorize(Role.Admin)]
        public async Task<IActionResult> CreateImageUrl([FromForm] Image images, int productId)
        {
            images.ImageName = await SaveImage(images.ImageFile);
            images.ImageSrc = String
               .Format("{0}://{1}{2}/wwwroot/{3}",
               Request.Scheme,
               Request.Host,
               Request.PathBase,
               images.ImageName);
            service.CreateImage(new ProductImage
            {
                ImageFile = images.ImageFile,
                ImageSrc = images.ImageSrc,
                ImageName = images.ImageName,
                ProductId = productId,
            },
            productId);
            return Created("create", images);
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
    }
}
