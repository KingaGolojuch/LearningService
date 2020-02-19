using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;
using System.Linq;

namespace LearningService.Domain.Mappers
{
    public class CourseDomainProfile : Profile
    {
        public CourseDomainProfile()
        {
            CreateMap<Course, CourseDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                ).ForMember(
                    dest => dest.UserId,
                    opt => opt.MapFrom(src => src.User.Id)
                ).ForMember(
                    dest => dest.UsersSubscribers,
                    opt => opt.MapFrom(src => src.UserCourseSubscription.Select(x => x.User.Id).ToList())
                );

            CreateMap<CourseDTO, Course>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                ).ForMember(
                    dest => dest.User,
                    opt => opt.MapFrom(src => new ApplicationUser(src.UserId))
                );
        }
    }
}
