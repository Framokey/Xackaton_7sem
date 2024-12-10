using DAL.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using Domain.Models;
using DAL.Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly WorkspacesDbContext _workspacesDbContext;

        public UserRepository(WorkspacesDbContext workspacesDbContext)
        {
            _workspacesDbContext = workspacesDbContext;
        }

        public async Task AddAsync(UserDto userDto)
        {
            Users user = new Users
            {
                Email = userDto.Email,
                Password = userDto.Password,
            };

            await _workspacesDbContext.Users.AddAsync(user);
            await _workspacesDbContext.SaveChangesAsync();

        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            Users? user = await _workspacesDbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return null;
            }

            return user;
        }
    }
}
