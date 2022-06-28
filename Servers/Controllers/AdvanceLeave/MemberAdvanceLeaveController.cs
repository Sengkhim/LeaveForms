using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

public class MemeberAdvanceLeaveController : MainController<MemeberAdvanceLeaveController>
{
    [HttpGet("/api/addvance-leave")]
    public async Task<IActionResult> GetAllAync()
    {
        return Ok(await _mediator.Send(new MemeberAdvanceLeaveQuery()));
    }
}