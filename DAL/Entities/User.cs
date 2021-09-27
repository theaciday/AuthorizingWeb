using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    public class User 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public Role Role { get; set; }
        [Required]
        public List<CartItem> UserCart { get; set; }
        [JsonIgnore]
        [Required]
        public string Password { get; set; }

    }
}
