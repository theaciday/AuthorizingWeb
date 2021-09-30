using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }

        public bool IsDisable { get; set; }

    }
}
