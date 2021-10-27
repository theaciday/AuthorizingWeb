﻿using BusLay.DTOs;
using DAL.Entities;
using DAL.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface ICartItemsService
    {
        public Task<List<CartItem>> GetCartItems(PaginationFilter filter, int id);
        public void DeleteFromCart(int id);
        public string AddToCart(CartDTO cartItem, int id);
        public int ItemsCount();
    }
}
