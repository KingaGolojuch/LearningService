using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseDTO, CourseViewModel>()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Name,
                   opt => opt.MapFrom(src => src.Name)
                ).ForMember(
                   dest => dest.CountUserSubscriberFinishedLesson,
                   opt => opt.MapFrom(src => $"{src.UserSubscriberFinishedLesson}/{src.LessonCount}")
                )
                .ReverseMap()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Name,
                   opt => opt.MapFrom(src => src.Name)
                );
        }
    }
}