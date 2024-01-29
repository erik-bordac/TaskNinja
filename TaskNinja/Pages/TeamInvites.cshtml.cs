using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages
{
    public class TeamInvitesModel : PageModel
    {
        ITeamInviteService _teamInviteService;

        [BindProperty]
        public List<TeamInvite> TeamInvites { get; set; }

        public TeamInvitesModel(ITeamInviteService teamInviteService)
        {
            _teamInviteService = teamInviteService;
        }

        public async void OnGet()
        {
            TeamInvites = await _teamInviteService.GetPendingInvitationsByRecipient(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
