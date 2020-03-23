using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

namespace Users.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpPost("get-users")]
        public ActionResult<IEnumerable<User>> Get()
        {
            return new List<User>
            {
                new User { Age = 18, Id = Guid.NewGuid(), Name = "John Doe" }
            };
        }
    }
}
