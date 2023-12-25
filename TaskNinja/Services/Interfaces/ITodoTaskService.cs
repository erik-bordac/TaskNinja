using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public interface ITodoTaskService
    {
        public Task<List<TodoTask>> GetAllAsync();
        public Task<TodoTask> GetByIdAsync(int id);
        public Task<TodoTask> CreateAsync(TodoTask task);
        public Task<TodoTask> DeleteAsync(TodoTask task);
    }
}
