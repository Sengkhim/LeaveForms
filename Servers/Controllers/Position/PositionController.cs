using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.Position
{
    public class PositionController : MainController<PositionController>
    {
        [HttpPost("/api/position")]
        public async Task<IActionResult> Create([FromBody] AddPositionCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/position")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllPositionQuery()));
        }

    }
}