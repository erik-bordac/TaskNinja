using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Security.Claims;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskNinja.Pages.TaskManager
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        ITodoTaskService _task_service;

        [BindProperty]
        public List<TodoTask> Tasks { get; set; } = new();


        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public string HideCompleted { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITodoTaskService taskService)
        {
            _logger = logger;
            _task_service = taskService;
        }

        public async void OnGet(string sortBy, string sortOrder, string hideCompleted)
        {
            // params for view component
            SortBy = sortBy;
            SortOrder = sortOrder;

            Tasks = await _task_service.GetAllAsync();
            Tasks = Tasks.Where(t => t.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
        }
    }
}
