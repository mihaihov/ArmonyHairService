using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Features.Emails.Responses
{
    public class SendEmailCommandResponse
    {
        public List<string>? Message { get; set; }
        public bool State { get; set; }
    }
}
