using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Helpers.Extensions;
using LearningService.WebApplication.Models.ActivityLog;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class ActivityProfile : Profile
    {
        public ActivityProfile()
        {
            CreateMap<ActivityLogDTO, ActivityLogViewModel>()
                .ForMember(
                    dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date)
                );
        }
    }
}