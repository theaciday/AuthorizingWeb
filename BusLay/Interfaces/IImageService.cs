using BusLay.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface IImageService
    {
        public int CreateProductImage(int productId, int imageId);
        public Image CreateImage(Image image); 
        public void RemoveImage(int id);

    }
}
