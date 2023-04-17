using Microsoft.AspNetCore.Identity;

namespace MessageApp.Models
{
    public class User : IdentityUser
    {
        public ICollection<ChatUser> Chats { get; set; }
    }
}
