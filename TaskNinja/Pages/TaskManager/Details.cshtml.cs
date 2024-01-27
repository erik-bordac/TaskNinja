using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using TaskNinja.Models;
using TaskNinja.Services;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TaskManager
{
    public class DetailsModel : PageModel
    {
        private ITodoTaskService _taskService;
        private ICommentService _commentService;
        private IUserService _userService;
        [BindProperty]
        public InputModel IM { get; set; } = new InputModel();

        [BindProperty]
        public TodoTask? Task { get; set; }

        [BindProperty]
        public Status Action { get; set; }

        [BindProperty]
        public List<Comment> Comments { get; set; } = new();

        public DetailsModel(ITodoTaskService taskService, ICommentService commentService, IUserService userService)
        {
            _taskService = taskService;
            _commentService = commentService;
            _userService = userService;
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
            if (!IsAuthor()) return Unauthorized();

            var task = _taskService.GetByIdAsync(id).Result;
            task.Status = Action;
            _taskService.DeleteAsync(task);
            return RedirectToPage("/TaskManager/Index");
        }

        public IActionResult OnPostComment(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var taskId = Task?.ID;
            if (!String.IsNullOrEmpty(IM.CommentText) && userId is not null && taskId is not null)
            {
                _commentService.CreateComment(new Comment { Content = IM.CommentText, 
                    TodoTaskID = (int)taskId,
                    CreatedDate = DateTime.Now,
                    UserId = userId});
            }

            return RedirectToPage("/TaskManager/Details", new { id = id });
        }

        public string UserNameFromId(string id)
        {
            var user = _userService.GetUserById(id).Result;
            return user._UserName;
        }

        public bool IsAuthor()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) == Task?.UserId;
        }

        private void loadPage(int id)
        {
            Task = _taskService.GetByIdAsync(id).Result;
            Comments = _commentService.GetAllFromTask(id).Result;
        }

        public class InputModel
        {
            [BindProperty, Required]
            public string CommentText { get; set; } = "";
        }
    }
}
