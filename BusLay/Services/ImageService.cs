using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BusLay.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository repository;
        public ImageService(IImageRepository repository)
        {
            this.repository = repository;
        }
        public ProductImageDTO CreateImage(ProductImage images,int id)
        {
            var image = repository.CreateImage(images,id);
            return new ProductImageDTO
            {
                ProductId = image.ProductId,
                ImageSrc=image.ImageSrc,
                ImageId = image.ImageId,
            };
        }

    }
}
