using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public interface ITeamInviteService
    {
        void AddInvitation(string senderId, string recipientId, int teamId);
    }
}
