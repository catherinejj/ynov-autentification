using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using EntityFramework;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("signin")]
        public IActionResult SignIn()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/auth/callback"
            };

            return Challenge(properties, GitHubAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        [HttpGet("callback")]
        public async Task<IActionResult> HandleCallBack()
        {
            await _userService.HandleSuccessfulSignin(User.Claims);
            return Ok();
        }
        
        [Authorize]
        [HttpGet("userinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userService.GetCurrent(User.Claims);
        
            return Ok(user);
        }
    }
}