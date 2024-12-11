using BLL.Services.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkspacesController : ControllerBase
    {
        private readonly IWorkspaceService _workspaceService;

        public WorkspacesController(IWorkspaceService workspaceService)
        {
            _workspaceService = workspaceService;
        }

        [HttpGet("Workspaces")]
        public async Task<ActionResult<IEnumerable<Workspaces>>> GetEntities()
        {
            var workspaces = await _workspaceService.GetAllWorkspaces();
            return Ok(workspaces);
        }

        [HttpGet("InfoUsers")]
        public async Task<ActionResult<IEnumerable<Workspaces>>> GetUserInfo(int userId)
        {
            var userInfo = await _workspaceService.GetUserInfo(userId);
            return Ok(userInfo);
        }
    }
}