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
        public async Task<IEnumerable<Team>> GetTeamsByMember(string userId)
        {
            var l = await _db.Team.ToListAsync();
            return l.Where(x => x.Members.All(m => m.Id == userId));
        }
    }
}
