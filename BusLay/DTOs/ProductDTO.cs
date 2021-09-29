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
    {
        [Required]
        public string ProductName { get; set; }

        public double UnitPrice { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
