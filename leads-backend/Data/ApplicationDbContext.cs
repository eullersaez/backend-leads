using leads_backend.Enums;
using leads_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace leads_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>()
                .HasOne(l => l.Contact)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.ContactId);


            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Phone = "1234567890" },
                new Contact { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "0987654321" }
            );

            modelBuilder.Entity<Lead>().HasData(
                new Lead
                {
                    Id = 1,
                    CreatedAt = new DateTime(2025, 1, 1),
                    Suburb = "Downtown",
                    Category = "Plumbing",
                    Description = "Fix leaking pipe",
                    Price = 150.00m,
                    ContactId = 1,
                    Status = LeadStatusEnum.Pending
                },
                new Lead
                {
                    Id = 2,
                    CreatedAt = new DateTime(2025, 1, 1),
                    Suburb = "Uptown",
                    Category = "Electrical",
                    Description = "Install new light fixtures",
                    Price = 200.00m,
                    ContactId = 2,
                    Status = LeadStatusEnum.Accepted
                },
                new Lead
                {
                    Id = 3,
                    CreatedAt = new DateTime(2025, 1, 1),
                    Suburb = "Uptown",
                    Category = "Electrical",
                    Description = "Install new light fixtures",
                    Price = 1000.00m,
                    ContactId = 2,
                    Status = LeadStatusEnum.Pending
                },
                new Lead
                {
                    Id = 4,
                    CreatedAt = new DateTime(2025, 1, 1),
                    Suburb = "Uptown",
                    Category = "Electrical",
                    Description = "Install new light fixtures",
                    Price = 100.00m,
                    ContactId = 2,
                    Status = LeadStatusEnum.Pending
                }
            );
        }
    }
}
