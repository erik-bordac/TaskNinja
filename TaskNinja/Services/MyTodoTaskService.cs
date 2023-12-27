using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Services
{
    public class MyTodoTaskService : ITodoTaskService
    {
        DatabaseContext _db;
        public MyTodoTaskService(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<TodoTask> CreateAsync(TodoTask task)
        {
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public Task<TodoTask> DeleteAsync(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoTask>> GetAllAsync()
        {
            return _db.Tasks.ToListAsync();
        }

        public async Task<TodoTask> GetByIdAsync(int id)
        {
            // Returns TodoTask object or null if doesnt exist

            var res = await _db.Tasks.FirstOrDefaultAsync(x => x.ID == id);
            #pragma warning disable CS8603 // Possible null reference return.
            return res;
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
