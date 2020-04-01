using System.Threading.Tasks;
using Models.Users;
using RestEase;

namespace Services.Users
{
    public interface IUserService
    {
        [Post("users/get-users")]
        Task<GetUsers.Response> GetUsersAsync(GetUsers.Request request);
    }
}
