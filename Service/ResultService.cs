using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ResultService : IResultService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly EntityChecker _entityChecker;

        public ResultService(IRepositoryManager repositoryManager, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _entityChecker = entityChecker;
        }

        public async Task CreateResult(Guid surveyId, ResultForCreationDTO resultForCreation)
        {
            await _entityChecker.CheckUserIfItExist(resultForCreation.UserId);
            await _entityChecker.CheckAnswerIfItExist(resultForCreation.QuestionId, resultForCreation.AnswerId);

            var result = _mapper.Map<Result>(resultForCreation);
            await _repositoryManager.Result.CreateResutl(result);
            await _repositoryManager.SaveAsync();
        }
    }
}
