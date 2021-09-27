using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public  ICollection<Product> Products { get; set; }

    }
}
