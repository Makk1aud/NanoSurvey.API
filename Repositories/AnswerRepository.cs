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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly NanoSurveyContext _context;

        public AnswerRepository(NanoSurveyContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetQuestionAnswer(Guid questionId, Guid AnswerId) =>
            await _context
            .Answers
            .AsNoTracking()
            .Where(x => x.QuestionId == questionId && x.AnswerId == AnswerId)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Answer>> GetQuestionAnswers(Guid questionId) =>
            await _context
            .Answers
            .AsNoTracking()
            .Where(x => x.QuestionId == questionId)
            .ToListAsync();
    }
}
