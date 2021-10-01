using DAL.Entities;
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
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Category> Categories { get; set; }
    }
}   
