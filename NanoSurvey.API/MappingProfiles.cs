using AutoMapper;
using Entities.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DataTransferObjects;

namespace NanoSurvey.API
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Question, QuestionDTO>();

            CreateMap<Answer, AnswerDTO>();

            CreateMap<ResultForCreationDTO, Result>();
        }
    }
}
