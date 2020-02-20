using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiTenant.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTenant.Api.Common.Controllers
{
    [Route("api/users")]
    public class UserControllers : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [ApiExplorerSettings(GroupName = "common")]
        public IActionResult Get()
        {
            return Ok(new List<User> { new User { Id = Guid.NewGuid(), Name = "John Doe" } });
        }
    }
}
