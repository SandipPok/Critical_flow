using System.ComponentModel.DataAnnotations;

namespace Critical_Flow.Models
{
    public class Message
    {
        [Required]
        public string? Subject { get; set; }

        [Required]
        public string? MailTo { get; set; }

        [Required]
        public string? MessageBody { get; set; }
    }
}