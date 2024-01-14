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
    public class ResultRepository : IResultRepository
    {
        private readonly NanoSurveyContext _context;

        public ResultRepository(NanoSurveyContext context)
        {
            _context = context;
        }

        public async Task CreateResutl(Result result) =>
            await _context.Results.AddAsync(result);       
    }
}
