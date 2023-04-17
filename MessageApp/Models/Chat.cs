﻿using MessageApp.Enums;

namespace MessageApp.Models
{
    public class Chat
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ChatType Type { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<ChatUser> ChatUsers { get; set; }
    }
}
