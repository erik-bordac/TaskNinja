using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TaskManager
{
    public class DetailsModel : PageModel
    {
        private ITodoTaskService _service;
        [BindProperty]
        public TodoTask? Task { get; set; }

        [BindProperty]
        public Status Action { get; set; }

        public DetailsModel(ITodoTaskService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            Task = _service.GetByIdAsync(id).Result;

            if (Task is null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public async void OnPost(int id)
        {
            var task = await _service.GetByIdAsync(id);
            task.Status = Action;
            Task = await _service.UpdateAsync(task);
        }

        public IActionResult OnPostDelete(int id)
        {
            var task = _service.GetByIdAsync(id).Result;
            task.Status = Action;
            _service.DeleteAsync(task);
            return RedirectToPage("/TaskManager/Index");
        }
    }
}
