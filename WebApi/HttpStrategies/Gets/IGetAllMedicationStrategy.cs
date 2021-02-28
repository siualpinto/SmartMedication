using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies.Gets
{
    public interface IGetAllMedicationStrategy
    {
        Task<IActionResult> ExecuteGetAllAsync();
    }
}
