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
        ITeamsService _teamsService;

        [BindProperty]
        public List<TeamInvite> TeamInvites { get; set; }

        public TeamInvitesModel(ITeamInviteService teamInviteService, ITeamsService teamsService)
        {
            _teamInviteService = teamInviteService;
            _teamsService = teamsService;
        }

        public async void OnGet()
        {
            TeamInvites = await _teamInviteService.GetPendingInvitationsByRecipient(User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public async Task<IActionResult> OnPostAccept(int id)
        {
            var inv = await _teamInviteService.GetInvitationByIdAsync(id);
            inv.Status = InviteStatus.Accepted;
            _teamInviteService.UpdateInvitation(inv);

            await _teamsService.AddUserToTeamAsync(inv.RecipientId, inv.TeamId);

            return RedirectToPage("TeamInvites");
        }
        public async Task<IActionResult> OnPostDecline(int id)
        {
            var inv = await _teamInviteService.GetInvitationByIdAsync(id);
            inv.Status = InviteStatus.Declined;
            _teamInviteService.UpdateInvitation(inv);

            return RedirectToPage("TeamInvites");
        }
    }
}
