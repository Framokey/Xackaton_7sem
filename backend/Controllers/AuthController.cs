using API.Http.Request;
using API.Http.Response;
using BLL.Services.Interfaces;
using DAL.Interfaces.User;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _context;

        public AuthController(
            IUserService userService,
            IHttpContextAccessor context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IResult> Register(string name, string password)
        {
            await _userService.Register(name, password);


            return Results.Ok();
        }

        [HttpPost("login")]
        public async Task<IResult> Login(LoginUserRequest request)
        {
            UserDto user = await _userService.Login(request.Name, request.Password);


            return Results.Ok(new UserResponse(name: user.UserName));
        }

        [HttpGet("refresh")]
        [Authorize]
        public IActionResult Refresh()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(Request.Cookies["Cookie"]);

            var userName = jwtToken.Claims.FirstOrDefault(c => c.Type == "userName")?.Value;

            if (userName == null)
            {
                return BadRequest();
            }

            return Ok(new UserResponse(name: userName));
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            _context.HttpContext?.Response.Cookies.Delete("Cookie");

            return Ok();
        }
    }
}