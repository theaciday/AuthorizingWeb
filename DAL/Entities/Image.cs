using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IFormFile ImageFile { get; set; }
        public string ImageSrc { get; set; }
        [JsonIgnore]
        public string ImageName { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}