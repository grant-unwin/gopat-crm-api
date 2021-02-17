using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models
{
    public class GopatContext : DbContext
    {
        public GopatContext(DbContextOptions<GopatContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Site> Sites { get; set; }

        public DbSet<TestSlot> TestSlots { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Site>()
                .HasOne(c => c.Company)
                .WithMany(p => p.Sites)
                .IsRequired()
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Company)
                .WithMany(p => p.Contacts)
                .IsRequired()
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Company)
                .WithMany(p => p.Contracts)
                .IsRequired()
                .HasForeignKey(p => p.CompanyId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Site)
                .WithMany(p => p.Contracts)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.SiteId);

            modelBuilder.Entity<Appointment>()
                .HasOne(c => c.Site)
                .WithMany(p => p.Appointments)
                .IsRequired()
                .HasForeignKey(p => p.SiteId);



            modelBuilder.Entity<TestSlot>()
                .HasOne(c => c.Site)
                .WithMany(c => c.TestSlots)
                .IsRequired()
                .HasForeignKey(p => p.SiteId);

            modelBuilder.Entity<TestSlot>()
                .HasOne(c => c.Contract)
                .WithMany(c => c.TestSlots)
                .HasForeignKey(p => p.ContractId);

            modelBuilder.Entity<TestSlot>()
                .HasOne(c => c.Company)
                .WithMany(c => c.TestSlots)
                .HasForeignKey(p => p.CompanyId);

        }

    }
}
