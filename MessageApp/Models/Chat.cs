using MessageApp.Enums;

namespace MessageApp.Models
{
    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
            ChatUsers = new List<ChatUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = "Chat";
        public ChatType Type { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
