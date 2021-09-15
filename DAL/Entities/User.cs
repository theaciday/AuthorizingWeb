using DAL.Entities;
using System.Text.Json.Serialization;

namespace BusLay.Entities
{
    public class User 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
        public CartItem User_Cart { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

    }
}
