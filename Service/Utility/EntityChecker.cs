using Contracts;
using Entities.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utility
{
    public class EntityChecker
    {
        private readonly IRepositoryManager _repositoryManager;

        public EntityChecker(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task CheckSurveyIfItExist(Guid surverId)
        {
            var survey = await _repositoryManager.Survey.GetSurvey(surverId);
            GenerateNotFoundException(surverId, survey);
        }

        public async Task<Question> CheckQuestionAndGetIfItExist(Guid surveyId, Guid questionId)
        {
            var question = await _repositoryManager.Question.GetSurveyQuestion(surveyId, questionId);           
            return GenerateNotFoundException(questionId, question);
        }

        public async Task CheckUserIfItExist(Guid userId)
        {
            var user = await _repositoryManager.User.GetUser(userId);
            GenerateNotFoundException(userId, user);
        }

        public async Task CheckAnswerIfItExist(Guid QuestionId, Guid answerId)
        {
            var answer = await _repositoryManager.Answer.GetQuestionAnswer(QuestionId, answerId);
            GenerateNotFoundException(answerId, answer);
        }

        private T GenerateNotFoundException<T>(Guid entityId, T entity)
        {
            if (entity is null)
                throw new NotFoundException($"Сущность типа {typeof(T).Name} с id {entityId} не найдена");
            return entity;
        }
    }
}
