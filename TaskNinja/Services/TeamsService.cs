using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Services
{
    public class TeamsService : ITeamsService
    {
        DatabaseContext _db;

        public TeamsService(DatabaseContext db)
        {
            _db = db;
        }

        public List<string> GetMembersIdByTeamId(int id)
        {
            var teamMemberIds = _db.Team
                .Where(t => t.Id == id)
                .SelectMany(t => t.Members.Select(m => m.Id))
                .ToList();

            return teamMemberIds;
        }

        public async Task<Team> GetTeamById(int id)
        {
            return await _db.Team.FirstOrDefaultAsync(t=> t.Id == id);
        }

        public IEnumerable<Team> GetTeamsByMember(string userId)
        {
            //var l = await _db.Team.ToListAsync();
            return _db.Team.Include(x => x.Members).Where(x => x.Members.Select(m => m.Id).Contains(userId));
            //return l.Where(x => x.Members.All(m => m.Id == userId));
        }

        public async Task<Team> AddUserToTeamAsync(string userId, int teamId)
        {
            // Retrieve the user and team from the database
            var user = await _db.Users.FindAsync(userId);
            var team = await _db.Team.FindAsync(teamId);

            // Check if user or team is null, handle accordingly
            if (user == null || team == null)
            {
                // Handle the case where user or team is not found
                return null;
            }

            // Add user to the team and update the database
            team.Members.Add(user);
            await _db.SaveChangesAsync();

            // Return the updated team
            return team;
        }
    }
}
