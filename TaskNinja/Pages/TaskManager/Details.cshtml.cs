using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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
        public InputModel IM { get; set; } = new InputModel();

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
            loadPage(id);

            if (Task is null)
            {
                return RedirectToPage("/Error");
            }


            return Page();
        }

        public async void OnPost(int id)
        {
            // update task entry
            var task = await _taskService.GetByIdAsync(id);
            task.Status = Action;
            await _taskService.UpdateAsync(task);

            loadPage(id);
        }

        public IActionResult OnPostDelete(int id)
        {
            var task = _taskService.GetByIdAsync(id).Result;
            task.Status = Action;
            _taskService.DeleteAsync(task);
            return RedirectToPage("/TaskManager/Index");
        }

        public IActionResult OnPostComment(int id)
        {
            if (!String.IsNullOrEmpty(IM.CommentText))
            {
                _commentService.CreateComment(new Comment { Content = IM.CommentText, TodoTaskID = Task.ID, CreatedDate = DateTime.Now });
            }

            return RedirectToPage("/TaskManager/Details", new { id = id });
        }

        private void loadPage(int id)
        {
            Task = _taskService.GetByIdAsync(id).Result;
            Comments = _commentService.GetAllFromTask(id).Result;
        }

        public class InputModel
        {
            [Required]
            [MinLength(1)]
            public string CommentText { get; set; }
        }
    }
}
