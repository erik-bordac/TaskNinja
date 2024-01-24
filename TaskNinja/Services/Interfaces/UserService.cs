using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public class UserService : IUserService
    {
        DatabaseContext _db;

        public UserService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<User> GetUserById(string id)
        {
            return await _db.Users.FirstAsync(x => x.Id == id);
        }
    }
}
