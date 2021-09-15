using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        
        public double? UnitPrice { get; set; }

        public string ImagePath { get; set; }
        
        [Required]
        public string Description { get; set; }


        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
