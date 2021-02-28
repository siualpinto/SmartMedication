using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies.Gets
{
    public interface IDeleteMedicationStrategy 
    {
        Task<IActionResult> ExecuteDeleteAsync(Guid key);
    }
}
