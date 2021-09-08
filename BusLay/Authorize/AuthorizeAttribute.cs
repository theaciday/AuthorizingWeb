﻿using BusLay.Models;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusLay.Authorize
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
   public class AuthorizeAttribute:Attribute,IAuthorizationFilter
    {
        private readonly IList<Role> _role;

        public AuthorizeAttribute(params Role[]role)
        {
            _role = role??new Role[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context) 
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var user = (User)context.HttpContext.Items["User"];
            if (user==null||(_role.Any()&&!_role.Contains(user.Role)))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
