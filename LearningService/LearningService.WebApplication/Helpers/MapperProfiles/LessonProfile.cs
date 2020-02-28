using AutoMapper;
using LearningService.Domain.Enums;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Models.Lesson;
using System.Web.Mvc;

namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<LessonDTO, LessonBaseViewModel>()
                .ForMember(
                    dest => dest.LessonType,
                    src => src.ResolveUsing(opt => Mapper.Map<string>(opt.LessonType))
                );

            CreateMap<LessonDTO, LessonTheoryViewModel>();
            CreateMap<LessonTheoryViewModel, LessonDTO>();

            CreateMap<LessonTheoryExamViewModel, LessonDTO>();
            CreateMap<LessonDTO, LessonTheoryExamViewModel>();

            CreateMap<LessonTheoryOptionViewModel, LessonComponentDTO>();
            CreateMap<LessonComponentDTO, LessonTheoryOptionViewModel>();

            CreateMap<LessonDTO, LessonTheoryExamLearningViewModel>();

            CreateMap<LessonComponentDTO, SelectListItem>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src.Id.ToString())
                ).ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => src.Name)
                );

            CreateMap<LessonPracticalExamViewModel, LessonDTO>()
                .ForMember(
                    dest => dest.ValidAnswer,
                    opt => opt.MapFrom(src => src.SelectedOption == "void" ? null : src.Answer)
                );

            CreateMap<LessonDTO, LessonPracticalExamViewModel>();

            CreateMap<LessonTypeCustom, string>().ConvertUsing(value =>
            {
                switch (value)
                {
                    case LessonTypeCustom.Theory:
                        return "Teoria";
                    case LessonTypeCustom.TheoryExam:
                        return "Test teoretyczny";
                    case LessonTypeCustom.PracticalExam:
                        return "Test praktyczny";
                    default:
                        return string.Empty;
                }
            });
        }
    }
}
