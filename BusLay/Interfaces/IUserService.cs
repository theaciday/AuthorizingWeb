using BusLay.DTOs;
using DAL.Entities;
using DAL.Models;
using System;

namespace DAL.Interfaces
{
    public interface IUserService
    {
        public User CreateUser(RegisterDto dto);
        public User NewUser(RegisterDto dto);
        public AuthenticateResponse LoginUser(AuthenticateRequest model);
        public User GetById(int id);
        //public IEnumerable<User> GetAll();
        public void DeletedUser(int id);
        public AuthenticateResponse GetCurrent(string token);
    }
}
