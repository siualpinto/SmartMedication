using BussinessLogic.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies.Post
{
    public interface IPostMedicationStrategy
    {
        Task<IActionResult> ExecutePostAsync(Medication medication);
    }
}
