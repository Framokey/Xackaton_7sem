using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IWorkspaceRepository
    {
        Task<IEnumerable<Workspaces>> GetAllWorkspaces();
    }
}
