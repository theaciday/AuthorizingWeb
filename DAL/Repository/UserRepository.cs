using BusLay.Context;
using BusLay.Interfaces;
using DAL.Entities;
using System;
using System.Linq;

namespace DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        public UserRepository(DataContext _context)
        {
            context = _context;
        }
        public User Create(User user)
        {
            context.Users.Add(user);
            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                user.Username = "a user with the same name already exists";
                user.FirstName = "a user with the same firstName already exists";
                return user;
            }

            return user;
        }

        public User GetUser(string username)
        {
            return context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }

        public User GetUserById(int id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }


        public string DeleteUser(int id)
        {
            var user = context.Users.First(u => u.Id == id);
            context.Remove(user);
            return ($"User with id:{id} has successeful deleted ");
        }



    }
}
