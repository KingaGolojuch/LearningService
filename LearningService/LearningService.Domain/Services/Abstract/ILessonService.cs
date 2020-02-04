using LearningService.Domain.ModelsDTO;
using System.Collections.Generic;

namespace LearningService.Domain.Services.Abstract
{
    public interface ILessonService
    {
        IEnumerable<LessonDTO> GetLessons(int courseId);
    }
}