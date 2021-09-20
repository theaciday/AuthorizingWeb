using BusLay.Context;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly UserRepository repository;
        private readonly DataContext context;
        public CartRepository(DataContext _context)
        {
            context = _context;
        }

        public string AddToCart(CartItem item)
        {
            context.ShoppingCartItems.Add(item);
            context.SaveChanges();
            return $"item with id: {item.ItemId} was added to your cart";
        }
        public void DeleteFromCart(int id)
        {
            var item = context.ShoppingCartItems.Where(s => s.ItemId == id).FirstOrDefault();
            context.ShoppingCartItems.Remove(item);
            context.SaveChanges();
        }

        public List<CartItem> GetCartItems(int id)
        {
            return context.ShoppingCartItems.Where(c => c.ItemId == id).ToList();
        }

    }
}
