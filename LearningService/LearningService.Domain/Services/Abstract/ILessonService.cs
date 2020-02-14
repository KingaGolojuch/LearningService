using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface ILessonService
    {
        LessonDTO GetLesson(int lessonId);
        IEnumerable<LessonDTO> GetLessons(int courseId);
        void AddLessonTheory(LessonDTO lessonDTO);
        void EditLessonTheory(LessonDTO lessonDTO);
    }
}