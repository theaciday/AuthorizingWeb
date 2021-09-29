using BusLay.Authorize;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        public IJwtUtils utils;
        private readonly ICartItemsService service;
        public CartController(ICartItemsService items,IJwtUtils utils)
        {
            this.utils = utils;
            service = items;
        }
        [Authorize]
        [HttpGet]
        public IActionResult CartItems()
        {
            var token = Request.Headers["Authorization"];
            var userId = utils.ValidateJwtToken(token);
            var items = service.GetCartItems((int)userId);
            return Ok(items);
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteFromCart(int? id)
        {
            if (id != null)
            {
                service.DeleteFromCart((int)id);
                return Ok();
            }
            
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        public IActionResult  AddToCart(CartItem item)
        {
            var token = Request.Headers["Authorization"];
            var userId = utils.ValidateJwtToken(token);
            var us = service.AddToCart(item, (int)userId);
            return Created("additem",us);

        }

    }
}
