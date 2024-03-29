﻿using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusLay.DTOs
{
    public class ProductDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; } = 0;
        public string Description { get; set; } = "";
        public List<ProductImageDTO> Images { get; set; }
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}   