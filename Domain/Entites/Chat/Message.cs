
using Domain.Authentication;

namespace Domain.Entites.Chat
{
    public class Message
    {
        public string Id { get; set; } = String.Empty;
        public string Content { get; set; }  = String.Empty;
        public DateTimeOffset Timestamp { get; set; }
        public User? FromUser { get; set; }
        public string ToRoomId { get; set; } = String.Empty;
        public Room? ToRoom { get; set; }
    }
}
