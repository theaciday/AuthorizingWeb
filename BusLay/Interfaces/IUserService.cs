using BusLay.DTOs;
using DAL.Entities;
using DAL.Models;

namespace DAL.Interfaces
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
