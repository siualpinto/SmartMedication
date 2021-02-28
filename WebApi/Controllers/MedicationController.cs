using BussinessLogic.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.HttpStrategies.Factories;
using WebApi.HttpStrategies.Gets;
using WebApi.HttpStrategies.Post;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly IFactory<IPostMedicationStrategy> _postMedicationStrategyFactory;
        private readonly IFactory<IDeleteMedicationStrategy> _deleteMedicationStrategyFactory;
        private readonly IFactory<IGetAllMedicationStrategy> _getAllMedicationStrategyFactory;

        public MedicationController(IFactory<IPostMedicationStrategy> postMedicationStrategyFactory,
            IFactory<IDeleteMedicationStrategy> deleteMedicationStrategyFactory, IFactory<IGetAllMedicationStrategy> getAllMedicationStrategyFactory)
        {
            _postMedicationStrategyFactory = postMedicationStrategyFactory;
            _deleteMedicationStrategyFactory = deleteMedicationStrategyFactory;
            _getAllMedicationStrategyFactory = getAllMedicationStrategyFactory;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            var getAllMedicationStrategy = _getAllMedicationStrategyFactory.Create();
            var result = await getAllMedicationStrategy.ExecuteGetAllAsync();
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicationAsync(Medication medication)
        {
            var postMedicationStrategy = _postMedicationStrategyFactory.Create();
            var result =  await postMedicationStrategy.ExecutePostAsync(medication);
            return result;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid key)
        {
            var deleteMedicationStrategy = _deleteMedicationStrategyFactory.Create();
            var result = await deleteMedicationStrategy.ExecuteDeleteAsync(key);
            return result;
        }
    }
}
