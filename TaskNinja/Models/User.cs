using Microsoft.AspNetCore.Identity;

namespace TaskNinja.Models
{
    public class User : IdentityUser
    {
        public string _UserName { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // reference navigation
    }
}
