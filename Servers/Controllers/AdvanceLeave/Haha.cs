using Application.Feature;
using Microsoft.AspNetCore.Mvc;
using Servers.Controllers.Mid;

namespace Servers.Controllers.AdvanceLeave
{
    public class Haha : MainController<Haha>
    {
        [HttpGet("api/haha")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _mediator.Send(new GetAllMemberAdvanceLeaveQuery()));
        }
    }
}
