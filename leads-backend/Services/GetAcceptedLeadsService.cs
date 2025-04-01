using leads_backend.Data;
using leads_backend.DTOs;
using leads_backend.Enums;
using Microsoft.EntityFrameworkCore;

namespace leads_backend.Services
{
    public class GetAcceptedLeadsService
    {
        private readonly ApplicationDbContext _context;
        public GetAcceptedLeadsService(ApplicationDbContext dbContext) {
           _context = dbContext;
        }

        public List<LeadDto> GetAcceptedLeads()
        {
            var acceptedLeads = _context.Leads.Where(l => l.Status == LeadStatusEnum.Accepted).Include(l => l.Contact).ToList();

            var acceptedLeadDtos = new List<LeadDto>();

            foreach (var lead in acceptedLeads)
            {
                acceptedLeadDtos.Add(Mappings.LeadToLeadDtoMapping.MapToLeadDto(lead));
            }

            return acceptedLeadDtos;
        }
    }
}
