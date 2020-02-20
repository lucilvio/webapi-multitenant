using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiTenant.Api.Filters
{
    public class TenantPermission : Attribute, IAuthorizationFilter
    {
        public TenantPermission(string tenant)
        {
            Tenant = tenant;
        }

        public string Tenant { get; private set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tenant = StringCipher.Decrypt(context.HttpContext.Request.Headers["key"], "");

            if (tenant != Tenant)
                context.Result = new NotFoundResult();
        }
    }
}