using CsApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsApp.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Complaint> Complaints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Complaint>().HasOne<Client>(s => s.Client).WithMany(c => c.Complaints).HasForeignKey(c => c.ClientId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
