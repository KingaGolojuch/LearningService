using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;
using LearningService.Helpers;

namespace LearningService.Domain.Mappers
{
    public class ArticleDomainProfile : Profile
    {
        public ArticleDomainProfile()
        {
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
                );

            CreateMap<ArticleDTO, Article>()
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
        }
    }
}
