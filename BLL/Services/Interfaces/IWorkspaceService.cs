using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IWorkspaceService
    {
        Task<IEnumerable<Workspaces>> GetAllWorkspaces();
        Task<IEnumerable<Users>> GetUserInfo(int userId);
    }
}
