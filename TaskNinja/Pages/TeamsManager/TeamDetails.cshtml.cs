using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using TaskNinja.Models;
using TaskNinja.Pages.TaskManager;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TeamsManager
{
    public class TeamDetailsModel : PageModel
    {
        [BindProperty]
        public Team Team { get; set; } = null!;

        [BindProperty]
        public List<TodoTask> TeamTasks { get; set; } = new();

        [BindProperty]
        public List<User> TeamMembers { get; set; } = new();

        [BindProperty, Required, EmailAddress]
        public string InviteMail { get; set; }

        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string HideCompleted { get; set; }

        ITeamsService _teamsService;
        IUserService _userService;
        ITodoTaskService _todoTaskService;
        ITeamInviteService _teamInviteService;

        public TeamDetailsModel(ITeamsService teamsService, IUserService userService, ITodoTaskService todoTaskService, ITeamInviteService teamInviteService)
        {
            _teamsService = teamsService;
            _userService = userService;
            _todoTaskService = todoTaskService;
            _teamInviteService = teamInviteService;
        }

        public class InputModel
        {
            [Required, EmailAddress]
            public string Mail { get; set; }
        }

        public async void OnGet(int teamId, string sortBy, string sortOrder, string hideCompleted)
        {
            var x = Url.Page(null);
            // params for view component
            SortBy = sortBy;
            SortOrder = sortOrder;
            HideCompleted = hideCompleted;

            // get teams
            Team = await _teamsService.GetTeamById(teamId);

            // get members
            var membersIds = _teamsService.GetMembersIdByTeamId(teamId);
            foreach (var id in membersIds)
            {
                TeamMembers.Add(await _userService.GetUserById(id));
            }

            // get tasks
            TeamTasks = await _todoTaskService.GetTasksByTeam(Team.Id);
        }

        public async Task<IActionResult> OnPostAsync(int teamId)
        {
            var recipient = await _userService.GetUserByMail(InviteMail);
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (recipient is not null)
            {
                // send invite
                _teamInviteService.AddInvitation(user, recipient.Id, teamId);
            }

            return RedirectToPage("/TeamsManager/TeamDetails", new { teamId = teamId });
        }

        public IActionResult OnPostRemoveMember(string userId, int teamId)
        {
            _teamsService.DeleteUser(userId, teamId);

            return RedirectToPage("/TeamsManager/Index");
        }
    }
}
