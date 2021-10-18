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
        public Image CreateImage(Image image) 
        {
           return repository.CreateImage(image);
        }
        public ProductImageDTO CreateProductImage(int productId,int imageId)
        {
            var image = repository.CreateProductImage(productId,imageId);
            return new ProductImageDTO
            {
            };
        }

    }
}
