using System.ComponentModel.DataAnnotations;

namespace API.Http.Request
{
    public record LoginUserRequest(
        [Required] string Name,
        [Required] string Password);
}
