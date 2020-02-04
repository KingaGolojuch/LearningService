using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;
using LearningService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningService.Domain
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
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
                )
                .ReverseMap()
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


            #region courses
            CreateMap<Article, ArticleDTO>()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Headline,
                   opt => opt.MapFrom(src => src.Headline)
                ).ForMember(
                   dest => dest.ContentArticle,
                   opt => opt.MapFrom(src => src.ContentArticle)
                ).ForMember(
                   dest => dest.Active,
                   opt => opt.MapFrom(src => src.Active)
                ).ForMember(
                   dest => dest.UserId,
                   opt => opt.MapFrom(src => src.User.Id)
                )
                .ReverseMap()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Headline,
                   opt => opt.MapFrom(src => src.Headline)
                ).ForMember(
                   dest => dest.ContentArticle,
                   opt => opt.MapFrom(src => src.ContentArticle)
                ).ForMember(
                   dest => dest.Active,
                   opt => opt.MapFrom(src => src.Active)
                ).ForMember(
                   dest => dest.User,
                   opt => opt.MapFrom(src => new ApplicationUser(src.UserId))
                );
            #endregion
        }
    }
}