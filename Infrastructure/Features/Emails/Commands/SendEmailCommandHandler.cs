using Infrastructure.Features.Emails.Responses;
using Infrastructure.Features.Emails.Validators;
using MediatR;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Features.Emails.Commands
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand,SendEmailCommandResponse>
    {
        private readonly IConfiguration _configuration;

        public SendEmailCommandHandler(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        public async Task<SendEmailCommandResponse> Handle(SendEmailCommand command, CancellationToken cancellationToken)
        {
            var response = new SendEmailCommandResponse();
            var validator = new SendEmailCommandValidator();
            var validationResult = await validator.ValidateAsync(command);

            response.Message = new List<string>();
            if(validationResult.Errors.Any())
            {
                response.State = false;
                foreach (var error in validationResult.Errors)
                    response.Message.Add(error.ErrorMessage);

            }
            else
            {
                try
                {
                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = Convert.ToInt32(_configuration["SmtpPort"]);
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(_configuration["SmtpUser"], _configuration["SmtpPassword"]);

                        var message = new MailMessage(command.Email!.SenderEmail, command.Email.RecipientEmail, command.Email.Subject, command.Email.Body);

                        await client.SendMailAsync(message);

                        response.State = true;
                        response.Message.Add("Message sent!");
                    }
                }
                catch(Exception ex)
                {
                    response.Message.Add(ex.Message);
                }
            }


            return response;
        }
    }
}
