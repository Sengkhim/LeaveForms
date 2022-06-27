using Application;
using Application.BusinessObejct;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.Member
{
    public class MemberTypeController : MainController<MemberTypeController>
    {
        [HttpPost("/api/member-type")]
        public async Task<IActionResult> Create([FromBody] AddMemberTypeCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
