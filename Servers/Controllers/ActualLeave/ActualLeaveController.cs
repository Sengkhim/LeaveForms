using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.ActualLeave
{
    public class ActualLeaveController : MainController<ActualLeaveController>
    {
        [HttpPost("/api/actual-leave")]
        public async Task<IActionResult> CreateAync([FromBody] AddActualLeaveCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/actual-leave")]
        public async Task<IActionResult> GetallAync()
        {
            return Ok(await _mediator.Send(new GetAllActualLeaveQuery()));
        }
    }
}
