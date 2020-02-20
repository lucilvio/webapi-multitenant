using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiTenant.Api.Filters
{
    public class Auth : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Request.Path == @"/api/token")
                return;

            if (!context.HttpContext.Request.Headers.ContainsKey("key"))
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }
    }
}