using AutoMapper;
using LearningService.Domain.ModelsDTO;
using LearningService.WebApplication.Models.Course;
using LearningService.WebApplication.Models.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LearningService.WebApplication.Helpers.MapperProfiles
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<LessonDTO, LessonBaseViewModel>();

            CreateMap<LessonDTO, LessonTheoryViewModel>();
            CreateMap<LessonTheoryViewModel, LessonDTO>();
        }
    }
}
