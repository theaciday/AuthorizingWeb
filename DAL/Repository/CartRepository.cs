using BusLay.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CartRepository: ICartRepository
    {
        private readonly DataContext context;
        public CartRepository(DataContext _context)
        {
            context = _context;
        }
        




    }
}
