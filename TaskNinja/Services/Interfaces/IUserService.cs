using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUserById(string id);
        Task<User?> GetUserByMail(string mail);
    }
}
