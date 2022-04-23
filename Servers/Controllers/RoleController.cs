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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize(Policy = Permissions.Users.View)]
        [HttpGet("get-all-roles")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roleService.GetAllAsync();
            return Ok(response);
        }

        [Authorize(Policy = Permissions.Roles.Create)]
        [HttpPost("create-role")]
        public async Task<IActionResult> Create(RoleRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return Ok(await _roleService.SaveAsync(request));
        }


        [Authorize(Policy = Permissions.Roles.Edit)]
        [HttpPut("update-role")]
        public async Task<IActionResult> UpdateRole(RoleRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return Ok(await _roleService.UpdateRoleAsync(request));
        }

        [Authorize(Policy = Permissions.Roles.View)]
        [HttpGet("permissions/{roleId}")]
        public async Task<IActionResult> GetPermissionsByRoleId([FromRoute] string roleId)
        {
            var response = await _roleService.GetAllPermissionsAsync(roleId);
            return Ok(response);
        }

        [Authorize(Policy = Permissions.Roles.Delete)]
        [HttpDelete("role/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _roleService.DeleteAsync(id);
            return Ok(response);
        }

        [Authorize(Policy = Permissions.Roles.Edit)]
        [HttpPut("permission/{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, PermissionRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (id != request.RoleId) return BadRequest();
            return Ok(await _roleService.UpdatePermissionsAsync(request));
        }

        [Authorize(Policy = Permissions.Users.CreatePermissionRole)]
        [HttpPost("permission/{id}")]
        public async Task<IActionResult> Create([FromRoute] string id, PermissionRequest request)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (id != request.RoleId) return BadRequest();
            return Ok(await _roleService.CreatePermissionsAsync(request));
        }
    }
}
