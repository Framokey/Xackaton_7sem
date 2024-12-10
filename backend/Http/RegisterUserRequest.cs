using System.ComponentModel.DataAnnotations;

namespace API.Http.Request
{
    public record RegisterUserRequest(
        [Required] string Email,
        [Required] string Password);
}
