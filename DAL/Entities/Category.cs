using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
