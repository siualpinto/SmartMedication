using BussinessLogic.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private IDbContextFactory<SmartMedicationDbContext> _dbContextFactory;

        public MedicationRepository(IDbContextFactory<SmartMedicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IQueryable<Medication> Query()
        {
            var context = _dbContextFactory.CreateDbContext();
            return context.Medications.AsQueryable();
        }

        public IQueryable<Medication> QueryById(Guid id)
        {
            var context = _dbContextFactory.CreateDbContext();
            var medication = context.Medications.Where(m => m.PKID.Equals(id));
            return medication;
        }

        public async Task<Medication> AddAsync(Medication medication)
        {
            var context = _dbContextFactory.CreateDbContext();
            await context.Medications.AddAsync(medication);
            await context.SaveChangesAsync();
            return medication;
        }

        public async Task DeleteAsync(Medication medication)
        {
            var context = _dbContextFactory.CreateDbContext();
            context.Medications.Remove(medication);
            await context.SaveChangesAsync();
        }
    }
}
