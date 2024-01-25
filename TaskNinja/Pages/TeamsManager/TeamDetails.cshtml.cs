using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Globalization;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TeamsManager
{
    public class TeamDetailsModel : PageModel
    {
        [BindProperty]
        public Team Team { get; set; }

        [BindProperty]
        public List<TodoTask> TeamTasks { get; set; } = new();

        [BindProperty]
        public List<User> TeamMembers { get; set; } = new();

        ITeamsService _teamsService;
        IUserService _userService;
        ITodoTaskService _todoTaskService;

        public TeamDetailsModel(ITeamsService teamsService, IUserService userService, ITodoTaskService todoTaskService)
        {
            _teamsService = teamsService;
            _userService = userService;
            _todoTaskService = todoTaskService;
        }

        public async void OnGet(int teamId)
        {
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
    }
}
