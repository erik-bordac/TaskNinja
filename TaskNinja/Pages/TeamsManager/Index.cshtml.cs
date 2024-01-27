using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TeamsManager
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Team> MyTeams { get; set; } = null!;
        ITeamsService _teamsService;

        public IndexModel(ITeamsService teamsService)
        {
            _teamsService = teamsService;
        }

        public void OnGet()
        {
            MyTeams = _teamsService.GetTeamsByMember(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
        }
    }
}
