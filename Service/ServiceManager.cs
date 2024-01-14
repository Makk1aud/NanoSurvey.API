using AutoMapper;
using Contracts;
using Service.Contracts;
using Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IQuestionService> _questionService;
        private readonly Lazy<IResultService> _resultService;
        private readonly EntityChecker _entityChecker;

        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _entityChecker = new EntityChecker(repositoryManager);
            _questionService = new Lazy<IQuestionService>(() => new QuestionService(repositoryManager, mapper, _entityChecker));
            _resultService = new Lazy<IResultService>(() => new ResultService(repositoryManager, mapper, _entityChecker));
        }
        public IQuestionService Question => _questionService.Value;

        public IResultService Result => _resultService.Value;
    }
}
