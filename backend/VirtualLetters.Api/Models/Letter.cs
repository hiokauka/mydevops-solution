namespace virtualletters.api.Models
{
    public class Letter
    {
        public string Id { get; set; }
        public string RecipientName { get; set; }
       
        public string SenderName { get; set; }

        public string Title { get; set; } 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
       
    }
}