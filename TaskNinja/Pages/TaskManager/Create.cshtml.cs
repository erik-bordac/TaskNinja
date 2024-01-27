using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskNinja.Models;
using TaskNinja.Services;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TaskManager
{
    public class CreateModel : PageModel
    {
        private readonly ITodoTaskService _context;

        public CreateModel(ITodoTaskService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (!User?.Identity?.IsAuthenticated ?? true)
            {
                return Unauthorized();
            }
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
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId != null)
                await _context.CreateAsync(new TodoTask
                {
                    Name = InputModel.Name,
                    Description = InputModel.Description,
                    CreatedDate = DateTime.Now,
                    DueDate = InputModel.DueDate,
                    Priority = InputModel.Priority,
                    Status = Models.Status.NotStarted,
                    UserId = userId
                });

            return RedirectToPage("./Index");
        }
    }

    public class InputModel
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime DueTime { get; set; }
        public Priority Priority { get; set; }
    }
}
