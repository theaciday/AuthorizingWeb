using BusLay.Context;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext context;

        public ImageRepository(DataContext context)
        {
            this.context = context;
        }
        public ProductImage CreateImage(ProductImage images,int id)
        {
            var image= new ProductImage
            {
                ImageId = images.ImageId,
                ImageSrc = images.ImageSrc,
                ImageName = images.ImageName,
                ProductId = id
            };
            context.Images.Add(image);
            context.SaveChanges();
            return image;
        }
    }
}
