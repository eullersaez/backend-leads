using leads_backend.Enums;

namespace leads_backend.Models.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Suburb { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int ContactId { get; set; }
        public LeadStatusEnum Status { get; set; }

        public Contact? Contact { get; set; }
    }
}
