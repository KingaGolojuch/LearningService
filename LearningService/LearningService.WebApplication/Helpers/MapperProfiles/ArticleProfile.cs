using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Models.Article;
using LearningService.WebApplication.Models.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO, ArticleBaseViewModel>()
                .ForMember(
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                   dest => dest.Headline,
                   opt => opt.MapFrom(src => src.Headline)
                ).ForMember(
                   dest => dest.ContentArticle,
                   opt => opt.MapFrom(src => src.ContentArticle)
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
                );
        }
    }
}