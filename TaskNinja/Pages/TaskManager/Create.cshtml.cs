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
using TaskNinja.Pages.TeamsManager;
using TaskNinja.Services;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Pages.TaskManager
{
    public static class Global
    {
        public static int? TeamId { get; set; } 
    }

    public class CreateModel : PageModel
    {
        private readonly ITodoTaskService _context;
        private ITeamsService _teamsService;


        public CreateModel(ITodoTaskService context, ITeamsService teamsService)
        {
            _context = context;
            _teamsService = teamsService;
        }

        public IActionResult OnGet(int? teamId)
        {
            if (teamId is not null) 
            {
                var team = _teamsService.GetTeamById((int)teamId);
                if (team is null)
                {
                    return Unauthorized();
                }

                // current user is not team => can not create tasks for the team
                if (!_teamsService.GetMembersIdByTeamId((int)teamId).Contains(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? ""))
                {
                    return Unauthorized();
                } else
                {
                    Global.TeamId = teamId;
                }
            }

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
                    UserId = userId,
                    TeamId = Global.TeamId
                });
            
            if (Global.TeamId is not null)
            {
                return RedirectToPage("/TeamsManager/TeamDetails", new {teamId = Global.TeamId});
            }
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
