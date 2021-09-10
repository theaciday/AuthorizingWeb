using BusLay.DataContext;
using BusLay.Entities;
using BusLay.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusLay.Repository
{
    public class UserRepository : DbContext, IUserRepository
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
                //user.Id = count++;
            }
            catch (Exception)
            {
                user.Username = "a user with the same name already exists";
                user.FirstName = "a user with the same firstName already exists";
                return user;
            }

            return user;
        }

        public  User GetUser(string username)
        {
            return context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }

        public  User GetUserById(int id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        

        public string DeleteUserById(int id)
        {
            var user = context.Users.First(u => u.Id == id);
            context.Remove(user);
            return  ($"User with id:{id} is deleted ");
        }


        
    }
}
