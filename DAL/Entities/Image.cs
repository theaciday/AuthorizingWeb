using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public string ImageSrc { get; set; }

        public string ImageName { get; set; }

        public ProductImage ImgEntity { get; set; }

    }
}