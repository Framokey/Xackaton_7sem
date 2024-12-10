using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Workspaces>> GetRoomsByWorkspace(int workspaceId, int capacity);
    }
}
