using BussinessLogic.Entities.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BussinessLogic.Loaders
{
    public class MedicationLoader : IMedicationLoader
    {
        private IMedicationRepository _medicationRepository;

        public MedicationLoader(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public async Task<IList<Medication>> GetAllAsync()
        {
            var query = _medicationRepository.Query();
            var medications = await query.ToListAsync();
            return medications;
        }

        public async Task<Medication> GetByIdAsync(Guid id)
        {
            var query = _medicationRepository.QueryById(id);
            var medication = await query.SingleOrDefaultAsync();
            return medication;
        }
    }
}
