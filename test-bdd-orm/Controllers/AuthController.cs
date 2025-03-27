using AspNet.Security.OAuth.GitHub;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EntityFramework;
using Services;

namespace Ynov.QuizYnov.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IUserService _userService ,IConfiguration _configuration) : ControllerBase
    {
        [HttpGet("signin")]
        [ProducesResponseType<User>(302)]
        public IActionResult SignIn([FromQuery] string redirectUri = "/auth/userinfo")
        {
            if (!IsAllowedRedirectUri(redirectUri))
            {
                return BadRequest("Invalid redirect uri");
            }

            var properties = new AuthenticationProperties
            {
                RedirectUri = $"/auth/callback?redirectUri={WebUtility.UrlEncode(redirectUri)}"
            };

            return Challenge(properties, GitHubAuthenticationDefaults.AuthenticationScheme);
        }

        [Authorize]
        [HttpGet("callback")]
        [ProducesResponseType<User>(302)]
        public async Task<IActionResult> HandleCallback([FromQuery] string redirectUri = "/auth/userinfo")
        {
           await _userService.HandleSuccessfulSignin(User.Claims);
            if (!IsAllowedRedirectUri(redirectUri)) {
                return BadRequest("Invalid redirect uri");
            }

            return Redirect(WebUtility.UrlDecode(redirectUri));
        }

        [Authorize]
        [HttpGet("userinfo")]
        [ProducesResponseType<User>(200)]
        public async Task<IActionResult> GetUserInfo()
        {
            var user = await _userService.GetCurrent(User.Claims);

            return Ok(user);
        }

        [HttpGet("signout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

      private bool IsAllowedRedirectUri(string redirectUri)
        {
            var allowedOrigins = _configuration.GetSection("AllowedRedirectOrigins").Get<string[]>() ?? [];

            return !redirectUri.StartsWith("/") || allowedOrigins.Any(origins=>redirectUri.StartsWith(origins));
            //return !redirectUri.Contains("/auth/signin")
            //   .StartsWith("/") || allowedOrigins.Any(origins => redirectUri.StartsWith(origins));
        }


    }

}
 