using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.ActualLeave
{
    public class MemberActualLeaveController : MainController<MemberActualLeaveController>
    {
        [HttpPost("/api/member-actual-leave")]
        public async Task<IActionResult> CreateAync([FromBody] AddMemberActualLeaveCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/member-actual-leave")]
        public async Task<IActionResult> GetallAync()
        {
            return Ok(await _mediator.Send(new GetAllMemberActualLeaveQuery()));
        }
    }
}
