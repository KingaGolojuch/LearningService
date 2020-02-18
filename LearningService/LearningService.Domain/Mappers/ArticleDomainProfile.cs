using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.Domain.ModelsDTO;

namespace LearningService.Domain.Mappers
{
    public class ArticleDomainProfile : Profile
    {
        public ArticleDomainProfile()
        {
            CreateMap<Article, ArticleDTO>()
                .ForMember(
                   dest => dest.UserId,
                   opt => opt.MapFrom(src => src.User.Id)
                );

            CreateMap<ArticleDTO, Article>()
                .ForMember(
                   dest => dest.User,
                   opt => opt.MapFrom(src => new ApplicationUser(src.UserId))
                );
        }
    }
}
