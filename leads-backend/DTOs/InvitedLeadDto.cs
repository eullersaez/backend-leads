namespace leads_backend.DTOs
{
    public class InvitedLeadDto
    {
        public int Id { get; set; }
        public required string ContactFirstName { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string Suburb { get; set; }
        public required string Category { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
    }
}
