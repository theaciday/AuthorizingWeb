using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.DTOs
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public string ImageSrc { get; set; }

    }
}
