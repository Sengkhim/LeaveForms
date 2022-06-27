using Application.Feature;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;
using Share.Permission;

namespace Servers.Controllers.Period
{
    public class PeriodController : MainController<PeriodController>
    {
       
        [HttpGet("/api/period")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _mediator.Send(new GetAllPeriodQuery());
            return Ok(data);
        }
        [HttpPost("/api/period")]
        public async Task<IActionResult> Create([FromBody] PeriodCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }
        
        [HttpDelete("/api/period")]
        public async Task<IActionResult> Create([FromBody] DeletePeriodCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }
    }
}
