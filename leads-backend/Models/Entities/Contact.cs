using System.Text.Json.Serialization;

namespace leads_backend.Models.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        [JsonIgnore]
        public List<Lead> Leads { get; set; } = new();
    }
}
