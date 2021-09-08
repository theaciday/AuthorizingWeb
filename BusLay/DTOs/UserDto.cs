using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.DTOs
{
   public class UserDto
    {
        [Required]
        public int Id { get; set; }
    }
}
