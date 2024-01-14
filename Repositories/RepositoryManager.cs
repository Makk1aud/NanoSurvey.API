using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly NanoSurveyContext _context;
        private readonly Lazy<IAnswerRepository> _answerRepository;
        private readonly Lazy<IQuestionRepository> _questionRepository;
        private readonly Lazy<IResultRepository> _resultRepository;
        private readonly Lazy<ISurveyRepository> _surveyRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public RepositoryManager(NanoSurveyContext context)
        {
            _context = context;
            _answerRepository = new Lazy<IAnswerRepository>(() => new AnswerRepository(_context));
            _questionRepository = new Lazy<IQuestionRepository>(() => new QuestionRepository(_context));
            _surveyRepository = new Lazy<ISurveyRepository>(() => new SurveyRepository(_context));
            _resultRepository = new Lazy<IResultRepository>(() => new ResultRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
        }

        public IAnswerRepository Answer => _answerRepository.Value;

        public IQuestionRepository Question => _questionRepository.Value;

        public ISurveyRepository Survey => _surveyRepository.Value;

        public IResultRepository Result => _resultRepository.Value;

        public IUserRepository User => _userRepository.Value;

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();
    }
}
