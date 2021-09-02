using BusLay.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusLay.Models
{
    public class User : IUser
    {
        public int Id { get; set ; }
        public string Name { get; set ; }
        public string Email { get ; set ; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
