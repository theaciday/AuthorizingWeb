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
            return context.Products.Count();
        }
        public async Task<List<CartItem>> GetCartItems(PaginationFilter filter, int id)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            using DataContext pop = context;
            var pagedData = await pop.ShoppingCartItems.Where(c => c.UserId == id).ToListAsync();

            return pagedData;
        }

    }
}
