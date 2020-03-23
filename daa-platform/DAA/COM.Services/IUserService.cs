using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Users;
using RestEase;

namespace Services
{
    public interface IUserService
    {
        [Post("users/get-users")]
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
