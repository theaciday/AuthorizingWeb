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
        public object CreateImages(Image images)
        {
            context.Images.Add(images);
            context.SaveChanges();
            return new
            {
                Id = images.Id,
                ImageSrc = images.ImageSrc,
                ImageName = images.ImageName,
                ProductId = images.ProductId
            };
        }
    }
}
