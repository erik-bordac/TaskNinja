using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TaskNinja.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        ITodoTaskService _task_service;

        [BindProperty]
        public List<TodoTask> Tasks { get; set; } = new();


        public string? SortOrder { get; set; } = "";
        public string SortBy { get; set; } = "";
        public string HideCompleted { get; set; } = "";

        public IndexModel(ILogger<IndexModel> logger, ITodoTaskService taskService)
        {
            _logger = logger;
            _task_service = taskService;
        }

        public async void OnGet(string sortBy, string sortOrder, string hideCompleted)
        {
            if (!String.IsNullOrEmpty(sortBy)) SortBy = sortBy;
            if (!String.IsNullOrEmpty(sortOrder)) SortOrder = sortOrder;
            if (!String.IsNullOrEmpty(hideCompleted)) HideCompleted = hideCompleted;

            Tasks = await _task_service.GetAllAsync();

            switch (sortBy)
            {
                case "ID":
                    Tasks = Tasks.OrderBy(x => x.ID).ToList();
                    break;
                case "Name":
                    Tasks = Tasks.OrderBy(x => x.Name).ToList();
                    break;
                case "Description":
                    Tasks = Tasks.OrderBy(x => x.Description).ToList();
                    break;
                case "CreatedDate":
                    Tasks = Tasks.OrderBy(x => x.CreatedDate).ToList();
                    break;
                case "DueDate":
                    Tasks = Tasks.OrderBy(x => x.DueDate).ToList();
                    break;
                case "Priority":
                    Tasks = Tasks.OrderBy(x => x.Priority).ToList();
                    break;
                case "Status":
                    Tasks = Tasks.OrderBy(x => x.Status).ToList();
                    break;
                default:
                    Tasks = Tasks.OrderBy(x => x.DueDate).ToList();
                    break;
            }

            if (SortOrder is not null && SortOrder == "desc")
            {
                Tasks.Reverse();
            }
        }

        public string SwitchSortOrder(string sortBy)
        {
            if (SortBy == sortBy)
            {
                if (String.IsNullOrEmpty(SortOrder))
                {
                    return "desc";
                }
            }
            return "";
        }

        public string SwitchHideCompleted()
        {
            if (String.IsNullOrEmpty(HideCompleted))
            {
                return "true";
            }

            return "";
        }
    }
}
