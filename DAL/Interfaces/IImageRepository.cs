using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IImageRepository
    {
        public int CreateProductImage(int productId, int imageId);
        public Image CreateImage(Image image);
        public void DeleteImage(int id);
    }
}
