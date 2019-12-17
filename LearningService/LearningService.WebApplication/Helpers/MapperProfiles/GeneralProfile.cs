using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TestEntity, TestDTO>()
                .ReverseMap();
        }
    }
}