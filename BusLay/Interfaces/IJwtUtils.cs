using BusLay.Entities;

namespace BusLay.Interfaces
{
    public interface IJwtUtils
    {

        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
