using Application;
using Application.Conmon.Request.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Share.Permission;

namespace Servers.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [Authorize(Policy = Permissions.Users.View)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [Authorize(Policy = Permissions.Users.SecretView)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetAsync(id);
            return Ok(user);
        }

        [HttpGet("roles/{id}")]
        public async Task<IActionResult> GetRolesAsync(Guid id)
        {
            var userRoles = await _userService.GetRolesAsync(id);
            return Ok(userRoles);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _userService.RegisterAsync(request, origin));
        }

        [Authorize(Policy = Permissions.Users.CreateClaimRole)]
        [HttpPost("claim-role")]
        public async Task<IActionResult> CreateRoleClaimAsyc(CreateUserRoleModel update)
        {
            return Ok(await _userService.CreateClaimRoleAsync(update));
        }


        [HttpGet("get-personal")]
        public async Task<IActionResult> GetPersonal() => Ok(await _userService.GetPersonal());


        [HttpPost("account/forgot-password")]
        ////[AllowAnonymous]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _userService.ForgotPasswordAsync(request.Email!, origin));
        }

        [HttpPost("reset-password")]
        //[AllowAnonymous]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            return Ok(await _userService.ResetPasswordAsync(request, request.Token!));
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] Guid userId, [FromQuery] string code)
        {
            return Ok(await _userService.ConfirmEmailAsync(userId, code));
        }
        //[HttpPost("create-user-claim")]
        //public async Task<IActionResult> CreateUserClaimAsync(UserClaimRequest request)
        //{
        //    return Ok(await _userService.CreateUserClaimAsync(request));
        //}

        //[Authorize(Policy = Permissions.Users.Edit, Roles = "Administrator")]
        //[HttpPut("roles/{id}")]
        //public async Task<IActionResult> UpdateRolesAsync(UpdateUserRolesRequest request)
        //{
        //    return Ok(await _userService.UpdateRolesAsync(request));
        //}

        //[HttpPost("update-role-claim")]
        //public async Task<IActionResult> UpdateRoleClaim(UpdateUserRoleModel update)
        //{
        //    return Ok(await _userService.UpdateRolesClaimAsync(update));
        //}


        //[HttpPost("forgot-password")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordRequest request)
        //{
        //    return Ok(await _userService.ForgotPasswordAsync(request.Email));
        //}

        //[HttpPost("reset-password")]
        //[AllowAnonymous]
        //public async Task<IActionResult> ResetPasswordAsync(ResetPasswordRequest request)
        //{
        //    return Ok(await _userService.ResetPasswordAsync(request));
        //}
    }
}
