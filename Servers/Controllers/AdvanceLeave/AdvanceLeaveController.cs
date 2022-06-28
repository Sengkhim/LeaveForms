using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.AdvanceLeave
{
    public class AdvanceLeaveController : MainController<AdvanceLeaveController>
    {
        [HttpPost("/api/addvance-leave")]
        public async Task<IActionResult> CreateAync([FromBody] AddAdvanceLeaveCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("/api/addvance-leave")]
        public async Task<IActionResult> GetAllAync()
        {
            return Ok(await _mediator.Send(new MemeberAdvanceLeaveQuery()));
        }
    }
    
}
     
