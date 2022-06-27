using Application.Conmon.Request.Identity;
using Application.Repositery.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Servers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IAccountService service, IHttpContextAccessor httpContextAccessor)
        {
            _service = service;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPut]
        [Route("/api/account/change-password")]
        public async Task<ActionResult> ChangePassword(ChangePasswordRequest model)
        {
            var userId =  _httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var response = await _service.ChangePasswordAsync(model, new Guid(userId));
            return Ok(response);
        }
    }
}
