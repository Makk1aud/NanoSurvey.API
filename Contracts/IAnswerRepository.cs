using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetQuestionAnswers(Guid questionId);
        Task<Answer> GetQuestionAnswer(Guid questionId, Guid AnswerId);
    }
}
