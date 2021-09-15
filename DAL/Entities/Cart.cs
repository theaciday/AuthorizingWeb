﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Cart
    {   
        [Key]
        public int Cart_Id { get; set; }
        
        public CartItem CartItem { get; set; }

    }
}
