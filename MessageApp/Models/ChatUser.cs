using MessageApp.Enums;
using Microsoft.AspNetCore.Identity;

namespace MessageApp.Models
{
    public class ChatUser
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int ChatId { get; set; }
        public ChatUser Chat { get; set; }
        public UserRole Role { get; set; }
    }
}
