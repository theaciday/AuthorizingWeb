using System;

namespace BusLay.Authorize
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute:Attribute{}
}
