using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Services
{
    public class CommentService : ICommentService
    {
        DatabaseContext _db;

        public CommentService(DatabaseContext db)
        {
            _db = db;
        }
        public Task<List<Comment>> GetAllFromTask(int taskId)
        {
            return _db.Comments.Where(x => x.TodoTaskID == taskId).ToListAsync();
        }

        public Task<Comment> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
