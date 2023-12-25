namespace TaskNinja.Models
{
    public class TodoTask
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
    }

    public enum Status
    {
        Completed,
        InProgress,
        NotStarted,
        Aborted
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
