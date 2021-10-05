using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DAL.Entities
{
    public class Category
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
        [JsonIgnore]
        public bool IsDisable { get; set; }

    }
}
