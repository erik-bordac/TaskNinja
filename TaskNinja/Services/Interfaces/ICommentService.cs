using TaskNinja.Models;

namespace TaskNinja.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<Comment> GetById(int id);
        public Task<List<Comment>> GetAllFromTask(int taskId);
        public void CreateComment(Comment comment);
    }
}
