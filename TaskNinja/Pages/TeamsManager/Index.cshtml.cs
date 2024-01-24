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
    public class IndexModel : PageModel
    {
        private readonly TaskNinja.Services.DatabaseContext _context;

        public IndexModel(TaskNinja.Services.DatabaseContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Team = await _context.Team.ToListAsync();
        }
    }
}
