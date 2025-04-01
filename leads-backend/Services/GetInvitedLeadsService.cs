using leads_backend.Data;
using leads_backend.DTOs;
using leads_backend.Enums;
using Microsoft.EntityFrameworkCore;

namespace leads_backend.Services
{
    public class GetInvitedLeadsService
    {
        private readonly ApplicationDbContext _context;
        public GetInvitedLeadsService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public List<InvitedLeadDto> GetInvitedLeads()
        {
            var pendingLeads = _context.Leads.Where(l => l.Status == LeadStatusEnum.Pending).Include(l => l.Contact).ToList();

            var invitedLeadDtos = new List<InvitedLeadDto>();

            foreach (var lead in pendingLeads)
            {
                invitedLeadDtos.Add(Mappings.LeadToInvitedLeadDtoMapping.MapToInvitedLeadDto(lead));
            }

            return invitedLeadDtos;
        }
    }
}
