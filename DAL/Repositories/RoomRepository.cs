using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly WorkspacesDbContext _context;

        public RoomRepository(WorkspacesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Workspaces>> GetRoomsByWorkspace(int workspaceId, int capacity)
        {
            return await _context.Rooms.Where(p => p.ID_WORKSPACE == workspaceId).ToListAsync();

        }
    }
}
