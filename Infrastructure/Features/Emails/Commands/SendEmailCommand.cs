using Domain.Entities;
using Infrastructure.Features.Emails.Responses;
using MediatR;

namespace Infrastructure.Features.Emails.Commands
{
    public class SendEmailCommand : IRequest<SendEmailCommandResponse>
    {
        public Email? Email { get; set; }
    }
}
