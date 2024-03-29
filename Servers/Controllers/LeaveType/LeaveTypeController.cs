﻿using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.RecordStatusType
{
    public class LeaveTypeController : MainController<LeaveTypeController>
    {
        [HttpPost("/api/leave-type")]
        public async Task<IActionResult> Create([FromBody] AddLeaveTypeCommand command)
        {
            if (command is null) return BadRequest();
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("/api/leave-type")]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = await _mediator.Send(new AddLeaveTypeCommand());
            return Ok(await _mediator.Send(query));

            
        }
    }
}
