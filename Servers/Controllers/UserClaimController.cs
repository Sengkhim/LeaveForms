using Application.Conmon.Request.Identity;
using Application.Repositery.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share.Permission;

namespace Servers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserClaimController : ControllerBase
    {
        private readonly IUserClaimService _service;

        public UserClaimController(IUserClaimService service)
        {
            _service = service;
        }

        [Authorize(Policy = Permissions.Users.CreateUserPermission)]
        [HttpPost("create-user-claim")]
        public async Task<IActionResult> CreatePermissionsAsync(UserClaimPermissions request)
        {
            return Ok(await _service.CreateUserPermissionsAsync(request));
        }

        [Authorize(Policy = Permissions.UserPermission.View)]
        [HttpGet("get-user-permission/{UserId}")]
        public async Task<IActionResult> GetUserPermission(string UserId)
        {
            return Ok(await _service.GetUserPermissionAsync(UserId));
        }

        [HttpPut("update-user-permission")]
        public async Task<IActionResult> UpdateUserPermissionsAsync(UserClaimPermissions request)
        {
            return Ok(await _service.UpdateUserPermissionsAsync(request));
        }
    }
}
