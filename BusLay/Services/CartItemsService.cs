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
            this.prodRep = prodRep;
            this.repository = repository;
        }
        public string AddToCart(CartDTO cartItem, int id)
        {
            CartItem cart = new()
            {
                DateCreated = DateTime.Today,
                ProductId = cartItem.ProductId,
                Quantity = 1,
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
            List<CartItemDTO> cartItemDTO = result.Select(item => new CartItemDTO
            {
                Price= (double)item.Product.UnitPrice,
                ProductName=item.Product.ProductName,
                ImageSrc = item.Product.Images.Select(o => o.ProductImgEntity.ImageSrc).ToList(),
                DateCreated=item.DateCreated,
                Id=item.Id,
                Quantity=item.Quantity,
            }).ToList();
            return cartItemDTO;
        }
    }
}