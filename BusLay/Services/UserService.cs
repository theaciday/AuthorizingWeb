using BusLay.DTOs;
using BusLay.Interfaces;
using BusLay.Settings;
using Microsoft.Extensions.Options;
using DAL.Models;
using System.Collections.Generic;
using BusLay.Helpers;
using System.Linq;
using DAL.Entities;
using System;
using BusLay.Context;
using DAL.Interfaces;

namespace BusLay.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repos;
        private readonly DataContext context;
        private readonly IJwtUtils jwtUtils;


        public UserService(IUserRepository repos, IJwtUtils _jwtUtils, DataContext _context)
        {
            context = _context;
            jwtUtils = _jwtUtils;
            _repos = repos;

        }

        public User CreateUser(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                FirstName = dto.FirstName,
                Email = dto.Email,
                LastName = dto.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = Role.User
            };
            _repos.Create(user);
            return user;
        }

        public AuthenticateResponse LoginUser(AuthenticateRequest model)
        { 
            try
            {
                var _user = _repos.GetByName(model.Username);
                if (!BCrypt.Net.BCrypt.Verify(model.Password, _user.Password))
                {
                    throw new AppException("Username or password is incorrect");
                }

                var jwtToken = jwtUtils.GenerateJwtToken(_user);
                return new AuthenticateResponse(_user, jwtToken);
            }
            catch (Exception)
            {
                throw new AppException("Username or password is incorrect");
            }
               
        }
        public AuthenticateResponse GetCurrent(string token)
        {
            try
            {
                var userId = jwtUtils.ValidateJwtToken(token);
                var user = GetById((int)userId);
                var jwtToken = jwtUtils.GenerateJwtToken(user);
                return new AuthenticateResponse(user, jwtToken);
            }
            catch (Exception)
            {
                return new AuthenticateResponse(new User(), "ERROR");
            }
        }
        public User GetById(int id)
        {
            var user = _repos.GetUserById(id);
            if (user == null)  
                return null;
            return user;
        }

        public string DeletedUser(int id)
        {
            var user = _repos.DeleteUser(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }


    }
}
