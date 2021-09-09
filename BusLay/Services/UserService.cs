using BusLay.DTOs;
using BusLay.Interfaces;
using BusLay.Entities;
using BusLay.Settings;
using Microsoft.Extensions.Options;
using DAL.Models;
using System.Collections.Generic;
using BusLay.Helpers;

namespace BusLay.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repos;
        private IJwtUtils jwtUtils;
        private readonly Setting appSettings;

        public UserService(IUserRepository repos, IJwtUtils _jwtUtils, IOptions<Setting> _appSettings)
        {
            jwtUtils = _jwtUtils;
            appSettings = _appSettings.Value;
            _repos = repos;

        }

        public User CreateUser(RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.UserName,
                FirstName = dto.FirstName,
                LastName=dto.LastName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Roles
            };
            _repos.Create(user);
            return user;
        }

        public AuthenticateResponse LoginUser(AuthenticateRequest model)
        {
            var _user = _repos.GetUser(model.Username);
            if (!BCrypt.Net.BCrypt.Verify(model.Password,_user.Password))
                throw new AppException("Username or password is incorrect");
            var jwtToken = jwtUtils.GenerateJwtToken(_user);

            return new AuthenticateResponse(_user, jwtToken);
        }
        public User GetById(int id)
        {
            var user = _repos.GetUserById(id);
            if (user==null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public string DeletedUser(int id)
        {
            var user = _repos.DeleteUserById(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        //public IEnumerable<User> GetAll()
        //{
        //    return; 
        //}
    }
}
