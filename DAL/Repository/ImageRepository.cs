﻿using BusLay.Context;
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
        public Image CreateImage(Image image)
        {
            context.Image.Add(image);
            context.SaveChanges();
            return image;
        }
        public ProductImage CreateProductImage(int productId, int imageId)
        {
            var imag = new ProductImage
            {
                ImageId = imageId,
                ProductId = productId
            };
            context.ProductImages.Add(imag);
            context.SaveChanges();
            return imag;
        }
    }
}
