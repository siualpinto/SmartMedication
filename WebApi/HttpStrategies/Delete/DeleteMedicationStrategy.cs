using BussinessLogic.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies.Gets
{
    public class DeleteMedicationStrategy : BaseStrategy, IDeleteMedicationStrategy
    {
        private IMedicationManager _medicationManager;

        public DeleteMedicationStrategy(IMedicationManager medicationManager)
        {
            _medicationManager = medicationManager;
        }

        public async Task<IActionResult> ExecuteDeleteAsync(Guid key)
        {
            var result = await TryExecuteAsync(() =>
            {
                return ExecuteAsync(key);
            });
            return result;
        }

        private async Task<IActionResult> ExecuteAsync(Guid key)
        {
            await _medicationManager.DeleteAsync(key);
            return CreateSuccessfulNoContentResult();
        }
    }
}
