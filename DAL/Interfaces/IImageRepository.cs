﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IImageRepository
    {
        public ProductImage CreateImage(ProductImage images,int id);
    }
}