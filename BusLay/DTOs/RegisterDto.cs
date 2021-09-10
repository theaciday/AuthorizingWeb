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
        public string Password { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public Role Roles { get; set; }
       
      
    }
}
