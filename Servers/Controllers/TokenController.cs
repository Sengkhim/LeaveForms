using Application.Conmon.Request.Identity;
using Application.Repositery.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presistance.DataBase;

namespace Servers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TokenController : ControllerBase
    {

        private readonly ITokenService _identityService;
        private readonly ICurrentUserService currentUserService;

        public TokenController(ITokenService identityService, ICurrentUserService currentUserService)
        {
            _identityService = identityService;
            this.currentUserService = currentUserService;
        }


        [HttpPost]
        public async Task<ActionResult> Get(TokenRequest model)
        {
            var response = await _identityService.LoginAsync(model);
            return Ok(response);
        }

        //[HttpPost("refresh")]
        //public async Task<ActionResult> Refresh([FromBody] RefreshTokenRequest model)
        //{
        //    var response = await _identityService.GetRefreshTokenAsync(model);
        //    return Ok(response);
        //}
    }
}
