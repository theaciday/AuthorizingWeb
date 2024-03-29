﻿using DAL.Entities;
using System;

namespace BusLay.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetUser(string username);
        User GetUserById(int id);
        void DeleteUser(int id);
        public User GetByName(string name);
    }
}
