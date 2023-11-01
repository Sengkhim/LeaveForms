using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.Departerment
{
    public class DepartmentController : MainController<DepartmentController>
    {

        [HttpPost("/api/department")]
        public async Task<IActionResult> Create([FromBody] AddDepartermentCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/department")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllDepartmentQuery()));
        }
    }
}
