using DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusLay.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        [JsonIgnore]
        public string Password { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public Role Roles { get; set; }
       
      
    }
}
