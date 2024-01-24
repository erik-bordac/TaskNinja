namespace TaskNinja.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TodoTaskID { get; set; }
        public TodoTask TodoTask { get; set; } = null!; // reference navigation
        
        public string UserId { get; set; }
        public User User { get; set; } = null!;   // reference navigation
    }
}
