using DAL.Entities;
using DAL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface ICartItemsService
    {
        public Task<List<CartItem>> GetCartItems(PaginationFilter filter,int id);
        public void DeleteFromCart(int id);
        public string AddToCart(CartItem cartItem, int id);
        public int ItemsCount();
    }
}
