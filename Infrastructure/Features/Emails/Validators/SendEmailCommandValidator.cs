using Domain.Entities;
using FluentValidation;
using Infrastructure.Features.Emails.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Features.Emails.Validators
{
    public class SendEmailCommandValidator : AbstractValidator<SendEmailCommand>
    {
        public SendEmailCommandValidator()
        {
            RuleFor(p => p.Email!.SenderEmail).NotEmpty().NotNull();
            RuleFor(p => p.Email!.RecipientEmail).NotEmpty().NotNull();
        }
    }
}
