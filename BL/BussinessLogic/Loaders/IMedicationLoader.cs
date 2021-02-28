using BussinessLogic.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLogic.Loaders
{
    public interface IMedicationLoader
    {
        Task<IList<Medication>> GetAllAsync();
        Task<Medication> GetByIdAsync(Guid id);
    }
}
