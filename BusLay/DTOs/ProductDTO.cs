using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.DTOs
{
    public class ProductDTO
    {   [Required]
        public string Name { get; set; }
        public double UnitPrice { get; set; } = 0;
        public string Description { get; set; } = "";
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}   
