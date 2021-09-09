using BusLay.Services;
using BusLay.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using BusLay.Authorize;
using DAL.Models;

namespace WebApplication2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly JWTService jWTService;
        private readonly UserService service;
        public UserController(UserService user, JWTService jWT)
        {
            service = user;
            jWTService = jWT;
        }

        //[Authorize(Role.Admin)]
        [HttpGet("user/userId")]
        public IActionResult GetUser(UserDto userDto)
        {
            try
            {
                var token = Request.Cookies["token"];
                var user = service.GetById(userDto);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }
    }
}
