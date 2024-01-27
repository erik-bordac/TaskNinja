using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public interface ITeamsService
    {
        public IEnumerable<Team> GetTeamsByMember(string userId);
        public Task<Team> GetTeamById(int id);
        public List<string> GetMembersIdByTeamId(int id);
        public Task<Team> AddUserToTeam(string userId, int teamId);
    }
}
