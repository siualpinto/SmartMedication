using BussinessLogic.Entities.Entities;
using DataAccess.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class SmartMedicationDbContext : DbContext
    {
        public SmartMedicationDbContext(DbContextOptions<SmartMedicationDbContext> options) : base(options)
        {
        }

        public DbSet<Medication> Medications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicationMapper());
        }
    }
}
