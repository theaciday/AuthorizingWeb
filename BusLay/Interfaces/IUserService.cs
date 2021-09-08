using BusLay.DTOs;
using BusLay.Models;

namespace BusLay.Interfaces
{
    public interface IUserService
    {
        public User CreateUser(RegisterDto dto);
        public User LoginUser(LoginDto user);
        public User GetById(UserDto dto);
        public string DeletedUser(UserDto dto);
    }
}
