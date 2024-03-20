using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Email
    {
        [Required]
        [EmailAddress]
        public string SenderEmail { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Subject { get; set; } = string.Empty;

        [Required]
        public string Body { get; set; } = string.Empty;

    }
}
