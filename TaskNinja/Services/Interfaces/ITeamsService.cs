using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public interface ITeamsService
    {
        public Task<IEnumerable<Team>> GetTeamsByMember(string userId);
    }
}
