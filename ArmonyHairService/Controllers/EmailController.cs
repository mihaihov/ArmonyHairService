using Infrastructure.Features.Emails.Commands;
using Infrastructure.Features.Emails.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArmonyHairService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IMediator _mediator;
        public EmailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sendemail", Name = "SendEmail")]
        public async Task<ActionResult<SendEmailCommandResponse>> SendEmail([FromBody] SendEmailCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
