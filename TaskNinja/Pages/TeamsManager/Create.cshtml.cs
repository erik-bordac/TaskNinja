using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskNinja.Models;
using TaskNinja.Services;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TeamsManager
{
    public class CreateModel : PageModel
    {
        private readonly TaskNinja.Services.DatabaseContext _context;
        IUserService _userService;

        public CreateModel(TaskNinja.Services.DatabaseContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userService.GetUserById(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            if (user == null) return Unauthorized();

            this.Team.Members.Add(user);

            _context.Team.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
