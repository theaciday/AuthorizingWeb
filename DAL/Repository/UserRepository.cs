using BusLay.DataContext;
using BusLay.Interfaces;
using BusLay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;
        public UserRepository(UserContext _context)
        {
            context = _context;
        }
        public User Create(User user)
        {
            context.Users.Add(user);
            try
            {
                var count = context.SaveChanges();
                user.Id = count++;
            }
            catch (Exception)
            {
                user.Name = "a user with the same name already exists";
                user.Email = "a user with the same name already exists";
                return user;   
            }
            
            return user;
        }
        public User GetByEmail(string email)
        {
            return context.Users.FirstOrDefault(u => u.Email == email);
        }
        public User GetById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id);
        }
    }
}
