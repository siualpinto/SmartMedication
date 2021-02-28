using BussinessLogic.Entities.Entities;
using BussinessLogic.Loaders;
using DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace BussinessLogic.Managers
{
    public class MedicationManager : IMedicationManager
    {
        private IMedicationRepository _medicationRepository;
        private IMedicationLoader _medicationLoader;

        public MedicationManager(IMedicationRepository medicationRepository, IMedicationLoader medicationLoader)
        {
            _medicationRepository = medicationRepository;
            _medicationLoader = medicationLoader;
        }

        public async Task<Medication> AddAsync(Medication medication)
        {
            if (medication.Quantity > 0)
            {
                return await _medicationRepository.AddAsync(medication);
            }
            else
            {
                throw new InvalidInputException("The amount of a medication cannot be lower than zero.");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var  medication = await _medicationLoader.GetByIdAsync(id);
            if(medication == null)
            {
                throw new NotFoundException($"The medication with Id '{id}' was not found.");
            }
            await _medicationRepository.DeleteAsync(medication);
        }
    }
}
