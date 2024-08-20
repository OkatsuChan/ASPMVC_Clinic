using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ClinicApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PatientPaymentModel> PatientPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure precision and scale for decimal properties
            modelBuilder.Entity<PatientPaymentModel>()
                .Property(p => p.AmountPaid)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PatientPaymentModel>()
                .Property(p => p.AmountCharge)
                .HasColumnType("decimal(18,2)");
        }
    }
}
