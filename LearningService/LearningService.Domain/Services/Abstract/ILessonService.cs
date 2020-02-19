using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface ILessonService
    {
        LessonDTO GetLesson(int lessonId);
        LessonDTO GetLesson(int lessonId, string userId);
        IEnumerable<LessonDTO> GetLessons(int courseId);
        IEnumerable<LessonDTO> GetLessons(int courseId, string userId);
        void AddLessonTheory(LessonDTO lessonDTO);
        void EditLessonTheory(LessonDTO lessonDTO);
        void AddTheoryTest(LessonDTO lessonDTO, IEnumerable<LessonComponentDTO> components);
        void EditTheoryTest(LessonDTO lessonDTO, IEnumerable<LessonComponentDTO> components);
        IEnumerable<LessonComponentDTO> GetLessonOptions(int lessonId);
        void AttemptPassTheoryTest(int lessonId, int answerId, string userId);
    }
}