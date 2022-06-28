using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.RecordStatusType
{
    public class RecordStatusTypeController : MainController<RecordStatusTypeController>
    {
        
        //private readonly IBusinessLogics _logics;

        //public RecordStatusTypeController(IBusinessLogics logics)
        //{
        //    _logics = logics;
        //}

        //[HttpPost("/api/recordStatus-type")]
        //public async Task<IActionResult> Create([FromBody] AddRecordStatusTypeCommand command)
        //{
        //    if (command is null) return BadRequest();
        //    return Ok(await _mediator.Send(command));
        //}
    }
}
