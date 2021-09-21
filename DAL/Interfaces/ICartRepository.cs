﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICartRepository
    {
        public List<CartItem> GetCartItems(int id);
        public void DeleteFromCart(int id);
        public string AddToCart(CartItem item);
    }
}