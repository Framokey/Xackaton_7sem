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
    [Route("Auth")]
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
        public async Task<IResult> Register(string email, string password)
        {
            await _userService.Register(email, password);


            return Results.Ok();
        }

        [HttpPost("login")]
        public async Task<IResult> Login(LoginUserRequest request)
        {
            UserDto user = await _userService.Login(request.Email, request.Password);


            return Results.Ok(new UserResponse(Email: user.Email));
        }

        [HttpGet("refresh")]
        [Authorize]
        public IActionResult Refresh()
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(Request.Cookies["Cookie"]);

            var Email = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            if (Email == null)
            {
                return BadRequest();
            }

            return Ok(new UserResponse(Email: Email));
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