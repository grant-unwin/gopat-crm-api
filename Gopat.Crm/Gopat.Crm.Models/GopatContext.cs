using System;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Models
{
    public class GopatContext : DbContext
    {
        public GopatContext(DbContextOptions<GopatContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

    }
}
