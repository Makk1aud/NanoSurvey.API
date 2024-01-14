using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IQuestionService
    {
        Task<QuestionDTO> GetQuestion(Guid surveyId, Guid questionId);
        Task<Guid?> GetNextQuestionId(Guid surveyId, Guid questionId);
    }
}
