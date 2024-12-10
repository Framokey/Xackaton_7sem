using Domain.Models;

namespace Utils.Jwt
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto userDto);
    }
}
