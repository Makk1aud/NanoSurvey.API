using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IQuestionRepository
    {
        Task<Question> GetSurveyQuestion(Guid surveyId,Guid questionId);
        Task<IEnumerable<Question>> GetSurveyQuestions(Guid surveyId);
    }
}
