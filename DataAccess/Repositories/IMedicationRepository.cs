using BussinessLogic.Entities.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IMedicationRepository
    {
        IQueryable<Medication> Query();
        IQueryable<Medication> QueryById(Guid id);
        Task<Medication> AddAsync(Medication medication);
        Task DeleteAsync(Medication medication);
    }
}
