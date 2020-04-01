using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Users;
using Users.Database;

namespace Users.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UsersContext _context;

        public UserController(UsersContext context)
        {
            _context = context;
        }

        [HttpPost("get-users")]
        public async Task<ActionResult<GetUsers.Response>> GetUsers([FromBody] GetUsers.Request request)
        {
            var users = _context.Users.Take(request.Take).Skip(request.Skip).ToListAsync();
            var response = new GetUsers.Response { Users = await users };
            return response;
        }
    }
}
