using BussinessLogic.Entities.Entities;
using System;
using System.Threading.Tasks;

namespace BussinessLogic.Managers
{
    public interface IMedicationManager
    {
        Task<Medication> AddAsync(Medication medication);
        Task DeleteAsync(Guid id);
    }
}
