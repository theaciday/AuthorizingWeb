using BusLay.Context;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly DataContext context;
        
        public CartRepository(DataContext _context)
        {
            context = _context;
        }

        public string AddToCart(CartItem item)
        {
            context.ShoppingCartItems.Add(item);
            context.SaveChanges();
            return $"item with id: {item.Id} was added to your cart";
        }
        public void DeleteFromCart(int id)
        {
            var item = context.ShoppingCartItems.Where(s => s.Id == id).FirstOrDefault();
            context.ShoppingCartItems.Remove(item);
            context.SaveChanges();
            //return $"item with id:{id} was successefuly deleted from your cart";
        }
        public int ItemsCount()
        {
            return context.ShoppingCartItems.Count();
        }
        public async Task<List<CartItem>> GetCartItems(PaginationFilter filter, int userId)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var cartItems = await context.ShoppingCartItems
                .Where(item => item.UserId == userId)
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .Include(d => d.Product)
                .ThenInclude(d => d.Images)
                .ThenInclude(s=>s.ProductImgEntity)
                .Include(d=>d.Product)
                .ThenInclude(d=>d.Categories)
                .ToListAsync();
            return cartItems;
        }
    }
}
