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
    public class SurveyRepository : ISurveyRepository
    {
        private readonly NanoSurveyContext _context;

        public SurveyRepository(NanoSurveyContext context)
        {
            _context = context;
        }

        public async Task<Survey> GetSurvey(Guid surveyId) =>
            await _context
            .Surveys
            .Where(x => x.SurveyId == surveyId)
            .SingleOrDefaultAsync();
    }
}
