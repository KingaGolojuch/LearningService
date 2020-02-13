using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Helpers.Extensions;
using LearningService.WebApplication.Models.Article;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDTO, ArticleBaseViewModel>()
                .ForMember(
                    dest => dest.CreateTime,
                    opt => opt.MapFrom(src => src.CreateTime.ToFullDateWithoutSeconds())
                ).ForMember(
                    dest => dest.UpdateTime,
                    opt => opt.MapFrom(src => src.UpdateTime.ToFullDateWithoutSeconds())
                );

            CreateMap<ArticleBaseViewModel, ArticleDTO>()
                .ForMember(
                    dest => dest.CreateTime,
                    opt => opt.Ignore()
                ).ForMember(
                    dest => dest.UpdateTime,
                    opt => opt.Ignore()
                );
        }
    }
}
