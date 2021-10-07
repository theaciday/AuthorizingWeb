using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
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
        public int ItemsCount()
        {
            return repository.ItemsCount();
        }

        public async Task<List<CartItem>> GetCartItems(PaginationFilter filter, int id)
        {
            return await repository.GetCartItems(filter, id);
        }


    }
}
