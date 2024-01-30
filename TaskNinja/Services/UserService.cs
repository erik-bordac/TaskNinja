using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Services
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

        public async Task<User?> GetUserByMail(string mail)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == mail);
        }
    }
}
