using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }

        public string CartId { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public double Products_Price { get; set; }

    }
}
