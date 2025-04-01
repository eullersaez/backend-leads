using leads_backend.DTOs;
using leads_backend.Models.Entities;

namespace leads_backend.Mappings
{
    public class LeadToInvitedLeadDtoMapping
    {
        public static InvitedLeadDto MapToInvitedLeadDto(Lead lead)
        {
            return new InvitedLeadDto
            {
                Id = lead.Id,
                ContactFirstName = lead.Contact.Name.Split(' ')[0],
                CreatedAt = lead.CreatedAt,
                Suburb = lead.Suburb,
                Category = lead.Category,
                Description = lead.Description,
                Price = lead.Price,
            };
        }
    }
}
