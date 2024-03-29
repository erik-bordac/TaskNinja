﻿using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services.Interfaces;

namespace TaskNinja.Services
{
    public class TeamInviteService : ITeamInviteService
    {
        DatabaseContext _db;
        public TeamInviteService(DatabaseContext db)
        {
            _db = db;
        }

        public void AddInvitation(string senderId, string recipientId, int teamId)
        {
            _db.TeamInvites.Add(new TeamInvite()
            {
                SenderId = senderId,
                RecipientId = recipientId,
                TeamId = teamId,
                CreatedDate = DateTime.Now,
                Status = InviteStatus.Pending
            });

            _db.SaveChangesAsync();
        }

        public Task<List<TeamInvite>> GetPendingInvitationsByRecipient(string userId)
        {
             return _db.TeamInvites.Where(i => i.RecipientId == userId && i.Status == InviteStatus.Pending).ToListAsync();
        }

        public async void UpdateInvitation(TeamInvite invitation)
        {
            _db.TeamInvites.Update(invitation);
            await _db.SaveChangesAsync();
        }

        public async Task<TeamInvite> GetInvitationByIdAsync(int id)
        {
            return await _db.TeamInvites.FirstAsync(i => i.Id == id);
        }
    }
}
