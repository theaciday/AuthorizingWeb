using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusLay.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartRepository repository;
        private readonly IProductRepository prodRep;
        public CartItemsService(ICartRepository repository, IProductRepository prodRep)
        {
            this.repository = repository;
        }
        public string AddToCart(CartDTO cartItem, int id)
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

        public async Task<List<CartItemDTO>> GetCartItems(PaginationFilter filter, int id)
        {
            var result = await repository.GetCartItems(filter, id);
            foreach (var item in result)
            {
                var productId = item.ProductId;
                var product = prodRep.FindProduct(id);
            }
           
            var dto = result.Select(item => new CartItemDTO
            {
                Id=item.Id,
                DateCreated=item.DateCreated,
                Product=product,
                Quantity=item.Quantity,
                UserId=item.UserId
            }).ToList();
            return dto;
        }


    }
}
