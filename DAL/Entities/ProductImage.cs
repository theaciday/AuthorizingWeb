using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public Image ProductImgEntity { get; set; }
    }
}
