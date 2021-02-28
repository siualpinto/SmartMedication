using BussinessLogic.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.HttpStrategies
{
    public abstract class BaseStrategy
    {
        public static IActionResult CreateSuccessfulResponse(object entity)
        {
            return new OkObjectResult(entity);
        }

        public static IActionResult CreateSuccessfulResponseMessage()
        {
            return new OkResult();
        }

        public static IActionResult CreateSuccessfulNoContentResult()
        {
            return new NoContentResult();
        }

        public static IActionResult CreateNotFoundResult()
        {
            return new NotFoundResult();
        }

        public static IActionResult CreateBadRequestResult()
        {
            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }

        protected async Task<IActionResult> TryExecuteAsync(Func<Task<IActionResult>> action)
        {
            IActionResult result;
            try
            {
                result = await action();
            }
            catch (Exception exception)
            {
                if (exception is NotFoundException)
                {
                    result = CreateNotFoundResult();
                }
                else if (exception is InvalidInputException)
                {
                    result = CreateBadRequestResult();
                }
                else
                {
                    result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            return result;
        }
    }
}
