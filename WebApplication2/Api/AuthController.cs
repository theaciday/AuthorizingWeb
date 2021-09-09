using BusLay.Authorize;
using BusLay.DTOs;
using BusLay.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly JWTService jWTService;
        private readonly UserService service;
        public AuthController(UserService user, JWTService jWT)
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
        public IActionResult Login(LoginDto user)
        {
            var _user = service.LoginUser(user);

            if (_user == null) return BadRequest(new { message = "User or password invalid" });
            if (!BCrypt.Net.BCrypt.Verify(user.Password, _user.Password)) return BadRequest(new { message = "wrong password" });

            var token = jWTService.Generate(_user);
            Response.Cookies.Append("token", token);

            return Ok(new
            {
                message = "success",
                token = token,
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new { message = "Success logout" });
        }
    }

}
