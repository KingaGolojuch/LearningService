using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
using LearningService.Domain.Enums;
using LearningService.Domain.ModelsDTO;
using LearningService.Domain.Services.Abstract;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Concrete
{
    public class LessonService : ILessonService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILessonRepository _lessonRepository;

        public LessonService(
            ICourseRepository courseRepository,
            ILessonRepository lessonRepository)
        {
            _courseRepository = courseRepository;
            _lessonRepository = lessonRepository;
        }

        public void AddLessonTheory(LessonDTO lessonDTO)
        {
            var course = _courseRepository.GetById(lessonDTO.CourseId);
            
            var newLesson = new Lesson
            {
                Course = new Course { Id = lessonDTO.CourseId },
                LessonType = new LessonType { Id = (int)LessonTypeCustom.Theory },
                OrderLesson = course.GetNextOrderLesson(),
                Headline = lessonDTO.Headline,
                LessonContent = lessonDTO.LessonContent
            };
            _lessonRepository.Add(newLesson);
        }

        public void EditLessonTheory(LessonDTO lessonDTO)
        {
            var lesson = _lessonRepository.GetById(lessonDTO.Id);
            lesson.SetHeadline(lessonDTO.Headline);
            lesson.SetContent(lessonDTO.LessonContent);

            if (!lesson.DataChanged)
                return;

            _lessonRepository.Update(lesson);
        }

        public LessonDTO GetLesson(int lessonId)
        {
            var lesson = _lessonRepository.GetById(lessonId);
            return Mapper.Map<LessonDTO>(lesson);
        }

        public IEnumerable<LessonDTO> GetLessons(int courseId)
        {
            var lessons = _lessonRepository.GetLessons(courseId);
            return Mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }
    }
}