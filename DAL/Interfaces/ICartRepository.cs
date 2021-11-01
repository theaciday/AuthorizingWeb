using DAL.Entities;
using DAL.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICartRepository
    {
        public Task<List<CartItem>> GetCartItems(PaginationFilter filter, int id);
        public void DeleteFromCart(int id);
        public string AddToCart(CartItem item);
        public int ItemsCount();
        public CartItem ChangeItemCount(int itemId, int count);

    }
}
