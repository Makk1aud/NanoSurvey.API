using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAnswerRepository Answer { get; }
        IQuestionRepository Question { get; } 
        ISurveyRepository Survey { get; } 
        IResultRepository Result { get; }
        IUserRepository User { get; }
        Task SaveAsync();
    }
}
