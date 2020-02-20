using ApiTenant.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Api.Common.Controllers
{
    [Route("api/token")]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        [ApiExplorerSettings(GroupName = "common")]
        public IActionResult Post([FromBody]TokenRequest request)
        {
            if (request.User != "john_doe" || request.Password != "password")
                return Unauthorized();

            return Created($"api/{request.Tenant}", new Token(request.Tenant));
        }
    }
}
