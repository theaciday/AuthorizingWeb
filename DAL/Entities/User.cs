using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL.Entities
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public Role Role { get; set; }
        public List<CartItem> UserCart { get; set; }
        [JsonIgnore]
        [Required]
        public string Password { get; set; }

    }
}
