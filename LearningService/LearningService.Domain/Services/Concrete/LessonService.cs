using AutoMapper;
using LearningService.DAO.Entities;
using LearningService.DAO.Repositories.Abstract;
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

        public IEnumerable<LessonDTO> GetLessons(int courseId)
        {
            var lessons = _lessonRepository.GetLessons(courseId);
            return Mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }
    }
}