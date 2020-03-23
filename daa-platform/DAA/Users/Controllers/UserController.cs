using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Users;
using RestEase;

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

    public interface IUserService
    {
        [Post("get-users")]
        Task<IEnumerable<User>> GetUsers();
    }
}
