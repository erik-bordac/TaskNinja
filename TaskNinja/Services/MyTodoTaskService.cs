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

        public Task<TodoTask> CreateAsync(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public Task<TodoTask> DeleteAsync(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoTask>> GetAllAsync()
        {
            return _db.Tasks.ToListAsync();
        }

        public Task<TodoTask> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
