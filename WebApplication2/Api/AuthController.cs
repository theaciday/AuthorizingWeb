using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IJwtUtils jWTService;
        private readonly IUserService service;
        public AuthController(IUserService user, IJwtUtils jWT)
        {
            service = user;
            jWTService = jWT;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            return Created("Success", service.CreateUser(dto));
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(AuthenticateRequest model)
        {
            var user = service.LoginUser(model);
            if (user == null) return BadRequest(new { message = "User or password invalid" });
            return Ok(user);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete(".AspNetCore.Application.Id");
            return Ok(new { message = "Success logout" });
        }
    }
}
