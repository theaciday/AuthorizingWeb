using BusLay.DTOs;
using BusLay.Entities;
using DAL.Models;
using System.Collections.Generic;

namespace BusLay.Interfaces
{
    public interface IUserService
    {
        public User CreateUser(RegisterDto dto);
        public AuthenticateResponse LoginUser(AuthenticateRequest model);
        public User GetById(int id);
        //public IEnumerable<User> GetAll();
        public string DeletedUser(int id);
        public AuthenticateResponse GetCurrent(string token);
    }
}
