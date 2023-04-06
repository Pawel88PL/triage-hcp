using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using triage_hcp.Models;

namespace triage_hcp
{
    public class DbTriageContext : IdentityDbContext<UserModel>
    {
        public DbTriageContext(DbContextOptions<DbTriageContext> options) : base(options) { }

        public DbSet<Pacjent> Pacjenci { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Pacjent>()
                .Property(p => p.Color)
                .IsRequired(false);
        }
    }
}
