using BusLay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.Interfaces
{
    public interface IUserRepository
    {
        User Create(User user);
        User GetUser(string username);
        User GetUserById(int id);
        string DeleteUserById(int id);
    }
}
