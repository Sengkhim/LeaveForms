using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

public class MemeberAdvanceLeaveController : MainController<MemeberAdvanceLeaveController>
{
    [HttpGet("/api/member-addvance-leave")]
    public async Task<IActionResult> GetAllAync()
    {
        return Ok(await _mediator.Send(new GetallMemeberAdvanceLeaveQuery()));
    }

    [HttpPost("/api/member-addvance-leave")]
    public async Task<IActionResult> CreateAync(AddMemberAdvanceLeaveCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
}