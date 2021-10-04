using Newtonsoft.Json;
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
        public int Id { get; set; }
            
        [Required]
        public string Name { get; set; }
        
        public double? UnitPrice { get; set; }

        public string ImagePath { get; set; }
        
        public string Description { get; set; }

        public IList<Category> Categories { get; set; } = new List<Category>();

        public bool IsDisable { get; set; } = false;
    }
}
