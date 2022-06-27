using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.RecordStatusType
{
    public class RecordStatusTypeMembercontroller : MainController<RecordStatusTypeMembercontroller>
    {
        [HttpPost("/api/recordStatus-type-member")]
        public async Task<IActionResult> Create([FromBody] RecordStatusTypeMemberCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }
    }
}
