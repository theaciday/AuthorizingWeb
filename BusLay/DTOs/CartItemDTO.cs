using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.DTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public DateTime DateCreated { get; set; }
        public List<string> ImageSrc{ get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

    }
}
