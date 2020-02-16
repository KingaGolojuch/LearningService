using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Models.Lesson;


namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<LessonDTO, LessonBaseViewModel>();

            CreateMap<LessonDTO, LessonTheoryViewModel>();
            CreateMap<LessonTheoryViewModel, LessonDTO>();

            CreateMap<LessonTheoryExamViewModel, LessonDTO>();
            CreateMap<LessonDTO, LessonTheoryExamViewModel>();

            CreateMap<LessonTheoryOptionViewModel, LessonComponentDTO>();
            CreateMap<LessonComponentDTO, LessonTheoryOptionViewModel>();
        }
    }
}
