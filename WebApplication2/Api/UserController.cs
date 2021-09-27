﻿using Microsoft.AspNetCore.Mvc;
using BusLay.Authorize;
using DAL.Entities;
using DAL.Interfaces;
using BusLay.Interfaces;
using BusLay.DTOs;
using System;

namespace WebApplication2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService service;
        public UserController(IUserService user)
        {
            service = user;
        }

        [Authorize(Role.Admin)]
        [HttpGet("{id:int}")]
        public IActionResult UserById(int id)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.UserId && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var user = service.GetById(id);
            return Ok(user);
        }

        [HttpGet("current")]
        public IActionResult CurrentUser()
        {
            var token = Request.Headers["Authorization"];
            var userServ = service.GetCurrent(token);
            return Ok(userServ);
        }
        [HttpPost]
        [Authorize(Role.Admin)]
        public IActionResult NewUser(RegisterDto dto)
        {
            return Created("Success", service.CreateUser(dto));
        }

        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var user = service.DeletedUser(id);
            return Ok(user);
        }
        
    }
}
