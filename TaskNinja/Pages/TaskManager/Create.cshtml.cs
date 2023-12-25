using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskNinja.Models;
using TaskNinja.Services;

namespace TaskNinja.Pages.TaskManager
{
    public class CreateModel : PageModel
    {
        private readonly TaskNinja.Services.DatabaseContext _context;

        public CreateModel(TaskNinja.Services.DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InputModel InputModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tasks.Add(new TodoTask
            {
                Name = InputModel.Name,
                Description = InputModel.Description,
                CreatedDate = DateTime.Now,
                DueDate = InputModel.DueDate,
                Priority = InputModel.Priority,
                Status = Models.Status.NotStarted
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }

    public class InputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime DueTime { get; set; }
        public Priority Priority { get; set; }
    }
}
