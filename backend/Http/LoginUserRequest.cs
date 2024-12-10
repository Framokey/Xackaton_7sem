using System.ComponentModel.DataAnnotations;

namespace API.Http.Request
{
    public record LoginUserRequest(
        [Required] string Email,
        [Required] string Password);
}
