using DAL.Entities;

namespace BusLay.DTOs
{
    public class ProductImageDTO
    {
        public string ImageSrc { get; set; }
        public int Id { get; set; }
        public Image ProductImageEntity { get; set; }
    }
}
