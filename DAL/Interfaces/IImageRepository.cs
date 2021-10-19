using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IImageRepository
    {
        public ProductImage CreateProductImage(int productId, int imageId);
        public Image CreateImage(Image image);
        public ProductImage DeleteImage(int id);
    }
}
