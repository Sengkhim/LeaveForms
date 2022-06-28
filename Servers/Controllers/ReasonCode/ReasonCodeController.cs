using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.ReasonCode
{
    public class ReasonCodeController : MainController<ReasonCodeController>
    {
        //[HttpPost("/api/reason-code")]
        //public async Task<IActionResult> Create([FromBody] AddReasonCodeCommand command)
        //{
        //    if (command is null) return BadRequest();
        //    return Ok(await _mediator.Send(command));
        //}

        //[HttpGet("/api/reason-code")]
        //public async Task<IActionResult> Get()
        //{
        //    var data = await _mediator.Send(new GetAllReasonCodeQuery());
        //    return Ok(data);
        //}
    }
}
