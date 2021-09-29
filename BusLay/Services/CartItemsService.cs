﻿using BusLay.Context;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartRepository repository;
        public CartItemsService(ICartRepository repository)
        {
            this.repository = repository;
        }
        public string AddToCart(CartItem cartItem, int id)
        {
            CartItem cart = new()
            {
                DateCreated = DateTime.Today,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                UserId = id
            };

            return repository.AddToCart(cart);
        }

        public void DeleteFromCart(int id)
        {
            repository.DeleteFromCart(id);
           
        }

        public List<CartItem> GetCartItems(int id)
        {
            return repository.GetCartItems(id);
        }


    }
}
