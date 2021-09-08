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
                UserName = dto.UserName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Roles
            };
            _repos.Create(user);
            return user;
        }

        public User LoginUser(LoginDto user)
        {
            var _user = _repos.GetUser(user.UserName);
            return _user;
        }
        public User GetById(UserDto dto)
        {
            return _repos.GetUserById(dto.Id);
        }
        public string DeletedUser(UserDto dto) 
        {
            return _repos.DeleteUserById(dto.Id);
        }
    }
}
