using BusLay.Authorize;
using BusLay.Helpers;
using BusLay.Interfaces;
using DAL.Entities;
using DAL.Filter;
using DAL.Interfaces;
using DAL.Wrappers;
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
        private readonly IUriService uriService;
        public CartController(ICartItemsService items,IJwtUtils utils, IUriService uriService)
        {
            this.utils = utils;
            service = items;
            this.uriService = uriService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CartItems([FromQuery]PaginationFilter filter)
        {
            try
            {
                var token = Request.Headers["Authorization"];
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var totalRecords = service.ItemsCount();
                var userId = utils.ValidateJwtToken(token);
                var items = await service.GetCartItems(filter, (int)userId);
                var PagedResponse = PaginationHelper.CreatePagedResponse<CartItem>(items, validFilter, totalRecords, uriService, route);
                return Ok(PagedResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

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
            try
            {
                var token = Request.Headers["Authorization"];
                var userId = utils.ValidateJwtToken(token);
                var us = service.AddToCart(item, (int)userId);
                return Created("additem", us);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
            
        }

    }
}
