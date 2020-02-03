using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;
using LearningService.Helpers;
using LearningService.WebApplication.Models.User;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.Surname)
                );
        }
    }
}