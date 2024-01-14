using Microsoft.AspNetCore.Mvc;
using NanoSurvey.API.ActionFilters;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System.Text.Json;

namespace NanoSurvey.API.Controllers
{
    [ApiController]
    [Route("api/surveys/{surveyId}/results")]
    public class ResultController : ControllerBase
    {
        private readonly IServiceManager _servicesManager;

        public ResultController(IServiceManager servicesManager)
        {
            _servicesManager = servicesManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateResult([FromBody] ResultForCreationDTO resultDTO, Guid surveyId)
        {
            var questionData = await _servicesManager.Question.GetNextQuestionId(surveyId, resultDTO.QuestionId);
            await _servicesManager.Result.CreateResult(surveyId, resultDTO);

            if(questionData is null)
                return NoContent();

            return Ok(questionData);
        }
    }
}
