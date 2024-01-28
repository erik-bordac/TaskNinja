using System.ComponentModel.DataAnnotations.Schema;

namespace TaskNinja.Models
{
    public class TeamInvite
    {
        public int Id { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; } = null!;   // reference navigation
        public string RecipientId { get; set; }
        public User Recipient { get; set; } = null!;    // reference navigation
        public int TeamId { get; set; }
        public Team Team { get; set; } = null!; // reference navigation
        public InviteStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ClosedDate { get; set; }    // when the invite changed from pending to other status
    }

    public enum InviteStatus
    {
        Pending,
        Accepted,
        Declined
    }
}
