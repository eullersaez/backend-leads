using leads_backend.DTOs;
using leads_backend.Models.Entities;

namespace leads_backend.Mappings
{
    public class LeadToLeadDtoMapping
    {
        public static LeadDto MapToLeadDto(Lead lead)
        {
            return new LeadDto
            {
                Id = lead.Id,
                Contact = lead.Contact,
                CreatedAt = lead.CreatedAt,
                Suburb = lead.Suburb,
                Category = lead.Category,
                Description = lead.Description,
                Price = lead.Price,
            };
        }
    }
}
