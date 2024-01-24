using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services;

namespace TaskNinja.Pages.TeamsManager
{
    public class DetailsModel : PageModel
    {
        private readonly TaskNinja.Services.DatabaseContext _context;

        public DetailsModel(TaskNinja.Services.DatabaseContext context)
        {
            _context = context;
        }

        public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Team.FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }
            else
            {
                Team = team;
            }
            return Page();
        }
    }
}
