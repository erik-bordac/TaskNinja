using Microsoft.AspNetCore.Identity;

namespace TaskNinja.Models
{
    public class User : IdentityUser
    {
        public required string _UserName { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // reference navigation
        public ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();  // reference navigation
        public List<Team> Teams { get; } = [];   // reference navigation
        public TeamInvite? Sender { get; set; }     // reference navigation
        public TeamInvite? Recipient { get; set; }  // reference navigation
    }
}
