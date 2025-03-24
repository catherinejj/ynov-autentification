using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFramework;
namespace Services
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /*private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /*[HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name))
                return BadRequest("Le nom de l'utilisateur est obligatoire.");

            var newUser = await _userService.AddUserAsync(user);
            return Ok(newUser);
        }
        public async Task<IActionResult> GetAllUsers(){
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }*/
    }
}