using BusLay.DTOs;
using BusLay.Interfaces;
using BusLay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace BusLay.Services
{
    public class UserService
    {
        private readonly IUserRepository _repos;
        
        public UserService(IUserRepository repos)
        {
             _repos=repos;
           
        }
        public User CreateUser(RegisterDto dto) 
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            _repos.Create(user);
            return user;
        }

        public User LoginUser(LoginDto dto)
        {
            var user = _repos.GetByEmail(dto.Email);
            return user;
           
        }
        public User GetById(int id) 
        {
            return _repos.GetById(id);
        }
    }
}
