using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private readonly WorkspacesDbContext _context;

        public WorkspaceRepository(WorkspacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workspaces>> GetAllWorkspaces()
        {
            return await _context.Workspaces.ToListAsync();
        }
        public async Task<IEnumerable<Users>> GetUserInfo(int userId)
        {
            return await _context.Users.AsQueryable()
                .Where(x => x.UserId == userId).ToListAsync();
        }
    }
} 
