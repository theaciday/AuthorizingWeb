using BusLay.Services;
using BusLay.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly JWTService jWTService;
        private readonly UserService service;
        public UserController(UserService user, JWTService jWT)
        {
            service = user;
            jWTService = jWT;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            return Created("Success",service.CreateUser(dto));
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
           
            var user = service.LoginUser(dto);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" }); 
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password)) return BadRequest(new { message = "Invalid Credentials" });

            var jwt = jWTService.Generate(user.Id);
            Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });

            return Ok(new
            {
                message = "success"
            });
        }
        [HttpGet("getuser")]
        public IActionResult GetUser() 
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = jWTService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = service.GetById(userId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex);
            }
           
        }
        [HttpPost("logout")]
        public IActionResult Logout() 
        {
            Response.Cookies.Delete("jwt");
            return Ok(new {message  = "Success logout" });
        }
    }
}
