using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<int> DeleteAsync(TodoTask task)
        {
            _db.Tasks.Remove(task);
            return await _db.SaveChangesAsync();
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

        public async Task<List<TodoTask>> GetTasksByTeam(int teamId)
        {
            return await _db.Tasks.Where(t => t.TeamId == teamId).ToListAsync();
        }

        public async Task<TodoTask> UpdateAsync(TodoTask newTask)
        {
            var t = _db.Tasks.FirstOrDefault(x => x.ID == newTask.ID);

            if (t is not null)
            {
                t = newTask;
                await _db.SaveChangesAsync();
                return t;
            }

            throw new KeyNotFoundException();
        }
    }
}
