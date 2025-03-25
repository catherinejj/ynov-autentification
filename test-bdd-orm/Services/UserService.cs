//public class UserService (UserDataAccess _dataAccess ): IUserService
using EntityFramework;
using System.Security.Claims;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess _dataAccess;

        public UserService(IUserDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task HandleSuccessfulSignin(IEnumerable<Claim> claims)
        {
            var emailClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            var nameClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (emailClaim != null && nameClaim != null)
            {
                var user = await _dataAccess.FindByEmail(emailClaim.Value);
                if (user == null)
                {
                    user = new User
                    {
                        Name = nameClaim.Value,
                        Email = emailClaim.Value,
                        Posts = new List<Post>()
                    };
                    await _dataAccess.Save(user);
                }
            }
        }

        public async Task<User?> GetCurrent(IEnumerable<Claim> claims)
        {
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            if (email != null)
            {
                return await _dataAccess.FindByEmail(email.Value);
            }
            return null;
        }
    }
}
