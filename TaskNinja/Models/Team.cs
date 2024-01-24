namespace TaskNinja.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; } = [];
        public ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();    // reference navigation 
    }
}
