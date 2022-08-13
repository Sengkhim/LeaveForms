
using Domain.Authentication;

namespace Domain.Entites.Chat
{
    public class Room
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public User? User { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
