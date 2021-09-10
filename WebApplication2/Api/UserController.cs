using Microsoft.AspNetCore.Mvc;
using BusLay.Authorize;
using BusLay.Entities;
using DAL.Entities;
using BusLay.Interfaces;

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
        [HttpGet("user/{id:int}")]
        public IActionResult UserById(int id)
        {
            var currentUser = (User)HttpContext.Items["User"];
            if (id != currentUser.Id && currentUser.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var user = service.GetById(id);
            return Ok(user);
        }
    }
}
