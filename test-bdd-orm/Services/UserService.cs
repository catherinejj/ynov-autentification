using EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Services
{
    /*public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        //est censé inserer des utilisateur sauf que ça n'a pas fonctionné meme après avoir créait en dure une boucle 
        //pour inserer des utilisateur donc j'ai fait une requete dans la console via sqlite
       public async Task<EntityFramework.User> AddUserAsync(EntityFramework.User user)
        {
            _context.Users.Add(user); 
            await _context.SaveChangesAsync();
            return user;
        }
        //affiche les gens
        public async Task<List<User>> GetAllUsersAsync(){
                return await _context.Users.ToListAsync();
        }
        
    }*/
}