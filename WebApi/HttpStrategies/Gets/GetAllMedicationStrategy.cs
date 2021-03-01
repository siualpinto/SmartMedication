using BussinessLogic.Loaders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies.Gets
{
    public class GetAllMedicationStrategy : BaseStrategy, IGetAllMedicationStrategy
    {
        private IMedicationLoader _medicationLoader;

        public GetAllMedicationStrategy(IMedicationLoader medicationLoader)
        {
            _medicationLoader = medicationLoader;
        }

        public async Task<IActionResult> ExecuteGetAllAsync()
        {
            var result = await TryExecuteAsync(() =>
            {
                return ExecuteAsync();
            });
            return result;
        }

        private async Task<IActionResult> ExecuteAsync()
        {
            var medications = await _medicationLoader.GetAllAsync();
            return CreateSuccessfulResponse(medications);
        }
    }
}
