using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNinja.Models;
using TaskNinja.Services;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TaskManager
{
    public class DetailsModel : PageModel
    {
        private ITodoTaskService _taskService;
        private ICommentService _commentService;
        [BindProperty]
        public TodoTask? Task { get; set; }

        [BindProperty]
        public Status Action { get; set; }

        [BindProperty]
        public List<Comment> Comments { get; set; }

        public DetailsModel(ITodoTaskService taskService, ICommentService commentService)
        {
            _taskService = taskService;
            _commentService = commentService;
        }

        public IActionResult OnGet(int id)
        {
            Task = _taskService.GetByIdAsync(id).Result;

            if (Task is null)
            {
                return RedirectToPage("/Error");
            }

            Comments = _commentService.GetAllFromTask(Task.ID).Result;

            return Page();
        }

        public async void OnPost(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            task.Status = Action;
            Task = await _taskService.UpdateAsync(task);
        }

        public IActionResult OnPostDelete(int id)
        {
            var task = _taskService.GetByIdAsync(id).Result;
            task.Status = Action;
            _taskService.DeleteAsync(task);
            return RedirectToPage("/TaskManager/Index");
        }
    }
}
