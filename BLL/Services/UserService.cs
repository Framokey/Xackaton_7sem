using DAL.Interfaces.User;
using DAL.Models;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using Utils.Jwt;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IHttpContextAccessor _context;

        public UserService(
            IUserRepository userRepository,
            IHttpContextAccessor context,
            IJwtProvider jwtProvider
            )
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _context = context;
        }

        public async Task Register(string name, string password)
        {
            var isUserExist = await _userRepository.GetUserByNameAsync(name);
            if (isUserExist != null)
            {
                throw new Exception("Пользователь с таким именем уже существует.");
            }

            if (password.Length < 8 || !HasSpecialCharacters(password) || !HasDigits(password) || !HasUpperCaseLetter(password))
            {
                throw new Exception("Невалидный пароль. Должен содержать не менее 8 символов, специальные символы, цифры и заглавную букву.");
            }

            var hashedPassword = Generate(password);

            UserDto userDto = new UserDto
            {
                UserName = name,
                Password = hashedPassword
            };

            await _userRepository.AddAsync(userDto);
            Console.WriteLine("Пользователь успешно зарегистрирован.");
        }

        public async Task<UserDto> Login(string name, string password)
        {
            Users user = await _userRepository.GetUserByNameAsync(name);

            var result = Verify(password, user.Password);

            if (result != true)
            {
                throw new Exception("Incorrenc password");
            }

            UserDto userDto = new UserDto
            {
                Id = user.UserId,
                UserName = user.Name,
            };

            string token = _jwtProvider.GenerateToken(userDto);

            _context.HttpContext?.Response.Cookies.Append("Cookie", token);

            return userDto;
        }

        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool Verify(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);

        private bool HasSpecialCharacters(string input)
        {
            return Regex.IsMatch(input, @"[!@#$%^&*(),.?\:{_}|<>]");
        }

        private bool HasDigits(string input)
        {
            return Regex.IsMatch(input, @"\d");
        }

        private bool HasUpperCaseLetter(string input)
        {
            return Regex.IsMatch(input, @"[A-Z]");
        }
    }
}
