using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DAL.Entities
{
    public class CartItem
    {
        [Key]
        public int ItemID { get; set; }
        [MaybeNull]
        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public Product Products { get; set; }

        public int ProductId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
    }
}
