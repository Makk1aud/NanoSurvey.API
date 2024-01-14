using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly NanoSurveyContext _context;

        public QuestionRepository(NanoSurveyContext context)
        {
            _context = context;
        }

        public async Task<Question> GetSurveyQuestion(Guid surveyId, Guid questionId) => 
            await _context.Questions
            .Where(x => x.SurveyId == surveyId && x.QuestionId == questionId)
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<Question>> GetSurveyQuestions(Guid surveyId) =>
            await _context
                .Questions
                .Where(x => x.SurveyId == surveyId)
                .OrderBy(x => x.QuestionId)
                .ToListAsync();
    }
}
