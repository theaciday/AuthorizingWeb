using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Helpers;
using BusLay.Interfaces;
using DAL.Filter;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public CartController(ICartItemsService items, IJwtUtils utils, IUriService uriService)
        {
            this.utils = utils;
            service = items;
            this.uriService = uriService;
        }
        [Authorize]
        [HttpGet("listitems")]
        public async Task<IActionResult> CartItems([FromQuery] PaginationFilter filter)
        {
            try
            {
                var token = Request.Headers["Authorization"];
                var route = Request.Path.Value;
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var totalRecords = service.ItemsCount();
                var userId = utils.ValidateJwtToken(token);
                var items = await service.GetCartItems(filter, (int)userId);
                var PagedResponse = PaginationHelper.CreatePagedResponse(items, validFilter, totalRecords, uriService, route);
                return Ok(PagedResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [Authorize]
        [HttpPut]
        [Route("changecount")]
        public IActionResult ChangeItemCount(CartItemDTO dTO)
        {
            service.ChangeItemCount(dTO.Id, dTO.Count);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("{itemId}/removeitem")]
        public IActionResult DeleteFromCart(int? itemId)
        {
            if (itemId != null)
            {
                service.DeleteFromCart((int)itemId);
                return Ok();
            }
            return BadRequest();
        }

        [Authorize]
        [HttpPost]
        [Route("cartitem")]
        public IActionResult AddToCart(CartDTO item)
        {
            try
            {
                var token = Request.Headers["Authorization"];
                if ((string)token == null)
                {
                    return Unauthorized();
                }
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
