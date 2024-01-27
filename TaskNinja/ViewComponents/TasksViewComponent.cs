using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Globalization;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.ViewComponents
{
    public class TasksViewComponent : ViewComponent
    {
        [BindProperty]
        public int Test { get; set; } = 50;

        public async Task<IViewComponentResult> InvokeAsync(ComponentParams par)
        {
            return View(par);
        }
    }

    public class ComponentParams
    {
        public string SortBy = "";
        public string? SortOrder { get; set; } = "";

        public List<TodoTask> Tasks { get; set; }
        public string HideCompleted { get; set; }
        public int? TeamId { get; set; }

        public ComponentParams(List<TodoTask> tasks, string sortBy, string sortOrder, string hideCompleted, int? teamId = null)
        {
            TeamId = teamId;
            Tasks = tasks;

            if (!string.IsNullOrEmpty(sortBy)) SortBy = sortBy;
            if (!string.IsNullOrEmpty(sortOrder)) SortOrder = sortOrder;
            if (!string.IsNullOrEmpty(hideCompleted)) HideCompleted = hideCompleted;

            SwitchHideCompleted();

            //SwitchSortOrder(sortBy);

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
                if (string.IsNullOrEmpty(SortOrder))
                {
                    return "desc";
                }
            }
            return "";
        }
        public string SwitchHideCompleted()
        {
            if (string.IsNullOrEmpty(HideCompleted))
            {
                return "true";
            }

            return "";
        }
    }
}
