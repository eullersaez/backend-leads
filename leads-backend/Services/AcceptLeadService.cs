using leads_backend.Data;
using leads_backend.DTOs;
using Microsoft.EntityFrameworkCore;

namespace leads_backend.Services
{
    public class AcceptLeadService
    {
        private readonly ApplicationDbContext _context;
        public AcceptLeadService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public LeadDto AcceptLead(int Id)
        {
            var lead = _context.Leads
                .Include(l => l.Contact)
                .FirstOrDefault(l => l.Id == Id);

            if (lead is not null) {
                lead.Status = Enums.LeadStatusEnum.Accepted;
                lead.Price = lead.Price > 500 ? lead.Price * new decimal(0.9) : lead.Price;

                _context.SaveChanges();

                FakeMailService.SendMail(lead.Contact.Email, "Your lead has been accepted!");

                return Mappings.LeadToLeadDtoMapping.MapToLeadDto(lead);
            }

            return null;
        }
    }
}
