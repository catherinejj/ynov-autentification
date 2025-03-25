using System.Security.Claims;
using EntityFramework;

namespace Services
{
    public interface IUserService
    {
        Task HandleSuccessfulSignin(IEnumerable<Claim> claims);
        Task<User?> GetCurrent(IEnumerable<Claim> claims);
    }
}