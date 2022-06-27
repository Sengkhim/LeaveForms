using Application;
using Application.Featur;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.Member
{
    public class MemberController : MainController<MemberController>
    {
        [HttpPost("/api/member")]
        public async Task<IActionResult> CreateAync([FromBody] AddMemberCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/member")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllMemberQuery()));
        }
    }
}
