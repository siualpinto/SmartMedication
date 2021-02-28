using BussinessLogic.Entities.Entities;
using BussinessLogic.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies.Post
{
    public class PostMedicationStrategy : BaseStrategy, IPostMedicationStrategy
    {
        private IMedicationManager _medicationManager;

        public PostMedicationStrategy(IMedicationManager medicationManager)
        {
            _medicationManager = medicationManager;
        }

        public async Task<IActionResult> ExecutePostAsync(Medication medication)
        {
            var result = await TryExecuteAsync(() =>
            {
                return ExecuteAsync(medication);
            });
            return result;
        }

        private async Task<IActionResult> ExecuteAsync(Medication medication)
        {
            if (medication.PKID == Guid.Empty)
            {
                medication.PKID = Guid.NewGuid();
            }
            var newMedication = await _medicationManager.AddAsync(medication);
            return CreateSuccessfulResponse(newMedication);
        }
    }
}
