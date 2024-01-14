using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Service.Utility;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly EntityChecker _entityChecker;

        public QuestionService(IRepositoryManager repositoryManager, IMapper mapper, EntityChecker entityChecker)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _entityChecker = entityChecker;
        }

        public async Task<QuestionDTO> GetQuestion(Guid surveyId, Guid questionId)
        {
            await _entityChecker.CheckSurveyIfItExist(surveyId);
            var question = await _entityChecker.CheckQuestionAndGetIfItExist(surveyId, questionId);
            var questionToReturn = _mapper.Map<QuestionDTO>(question);

            var answers = await _repositoryManager.Answer.GetQuestionAnswers(questionId);
            var answersDTO = _mapper.Map<IEnumerable<AnswerDTO>>(answers);
            questionToReturn.Answers = answersDTO;

            return questionToReturn;
        }

        public async Task<Guid?> GetNextQuestionId(Guid surveyId, Guid questionId)
        {
            await _entityChecker.CheckSurveyIfItExist(surveyId);

            var previousQuestion = await _repositoryManager.Question.GetSurveyQuestion(surveyId, questionId);
            var questions = await _repositoryManager.Question.GetSurveyQuestions(surveyId);

            var questionIndex = questions.ToList().IndexOf(previousQuestion) + 1;

            return questionIndex < questions.Count()
                ? questions.ElementAt(questionIndex).QuestionId
                : null;
        }
    }
}
