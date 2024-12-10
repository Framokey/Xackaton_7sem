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
    public class WorkspaceService : IWorkspaceService
    {
        private readonly IWorkspaceRepository _repository;

        public WorkspaceService(IWorkspaceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Workspaces>> GetAllWorkspaces()
        {
            return await _repository.GetAllWorkspaces();
        }
    }
}
