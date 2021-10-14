using BusLay.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository repository;
        public ImageService(IImageRepository repository)
        {
            this.repository = repository;
        }
        public object CreateImage(Image images)
        {
            return repository.CreateImages(images);
        }
      
    }
}
