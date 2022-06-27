using Application.Featur;
using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.Departerment
{
    public class DepartermentController : MainController<DepartermentController>
    {
        
        [HttpPost("/api/departerment")]
        public async Task<IActionResult> Create([FromBody] AddDepartermentCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/departerment")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllDepartermentQuery()));
        }
    }
}
