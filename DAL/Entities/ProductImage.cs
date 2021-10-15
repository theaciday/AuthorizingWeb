using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ProductImage : Image
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("imageId")]
        public int  ImageId { get; set; }
        public Image ProductImgEntity { get; set; }
    }
}