
namespace TaskNinja.Models
{
    public class TodoTask
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();   // reference navigation
        public string UserId { get; set; }
        public User User { get; set; } = null!;   // reference navigation
    }

    public enum Status
    {
        Completed,
        InProgress,
        NotStarted
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
