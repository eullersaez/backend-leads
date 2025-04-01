using leads_backend.Data;
using leads_backend.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace leads_backend.Services
{
    public class DeclineLeadService
    {
        private readonly ApplicationDbContext _context;
        public DeclineLeadService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public LeadDto DeclineLead(int Id)
        {
            var lead = _context.Leads.Find(Id);
            
            if (lead is not null)
            {
                lead.Status = Enums.LeadStatusEnum.Declined;
                _context.SaveChanges();

                return Mappings.LeadToLeadDtoMapping.MapToLeadDto(lead);
            }

            return null;
        }
    }
}
