using DAL.Models;
using System.Text.Json.Serialization;

namespace BusLay.Models
{
    public class User 
    {
        public int Id { get; set ; }
        public string UserName { get; set ; }
        public string Email { get ; set ; }
        public Role Role { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        
    }
}
