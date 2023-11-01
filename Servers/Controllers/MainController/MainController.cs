using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Servers.Controllers.Mid
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MainController<T> : ControllerBase
    {
        private ILogger<T>? _loggerInstance;
        private IMediator? _mediatorInstance;

        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}
