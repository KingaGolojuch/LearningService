using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;
using LearningService.Helpers;

namespace LearningService.Domain.Mappers
{
    public class LessonDomainProfile : Profile
    {
        public LessonDomainProfile()
        {
            CreateMap<Lesson, LessonDTO>();
        }
    }
}
