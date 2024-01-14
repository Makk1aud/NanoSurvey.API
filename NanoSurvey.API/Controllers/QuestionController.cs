using Microsoft.AspNetCore.Mvc;
using Repositories;
using Service.Contracts;

namespace NanoSurvey.API.Controllers
{
    [ApiController]
    [Route("api/survey/{surveyId}/questions")]
    public class QuestionController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public QuestionController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{questionId}")]
        public async Task<IActionResult> GetQuestion(Guid surveyId, Guid questionId)
        {
            var questions = await _serviceManager.Question.GetQuestion(surveyId, questionId);
            return Ok(questions);
        }
    }
}
