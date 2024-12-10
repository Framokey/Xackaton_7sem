using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BLL.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Workspaces>> GetRoomsByWorkspace(int workspaceId, int capacity)
        {
            return await _repository.GetRoomsByWorkspace(int workspaceId, int capacity);
        }
    }
}
