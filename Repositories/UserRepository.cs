using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NanoSurveyContext _context;

        public UserRepository(NanoSurveyContext context)
        {
            _context = context;
        }

        public Task<User> GetUser(Guid userId) =>
            _context
            .Users
            .Where(x => x.UserId == userId)
            .SingleOrDefaultAsync();
    }
}
