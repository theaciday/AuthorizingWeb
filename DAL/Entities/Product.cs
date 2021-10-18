using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{

    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        public double? UnitPrice { get; set; }
        public string Description { get; set; }
        public List<ProductImage> Images { get; set; } = new List<ProductImage>();
        public List<Category> Categories { get; set; } = new List<Category>();
        [JsonIgnore]
        public bool IsDisable { get; set; } = false;
    }
}
