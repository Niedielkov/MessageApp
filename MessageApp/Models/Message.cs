namespace MessageApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }

    }
}
