using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class UserDataAccess(ApplicationDbContext _dbContext) : IUserDataAccess
    {
        public async Task Save(User user)
        {
           _dbContext.Users.Add(user);//gére le user
           await _dbContext.SaveChangesAsync();//applique le changement
        }

        public async Task<User> FindByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}