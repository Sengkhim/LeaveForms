using System.ComponentModel.DataAnnotations;

namespace Application.Conmon
{
    public class MessageViewModel
    {
        [Required]
        public string Content { get; set; } = String.Empty;
        public string Timestamp { get; set; } = String.Empty;
        public string From { get; set; } = String.Empty;
        [Required]
        public string Room { get; set; } = String.Empty;
        public string Avatar { get; set; } = String.Empty;
    }
}
